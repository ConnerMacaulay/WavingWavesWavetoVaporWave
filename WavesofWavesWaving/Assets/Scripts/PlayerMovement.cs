using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public int health;
	public float playerSpeed;
	public Vector2 playerDestination;
	public bool colliding = false;

	public float playerDist = 0.05f;
	public LayerMask mask = 1 << 8;
	public float rayLength = 0.1f;

	public bool colUp= false;
	public bool colDown = false;
	public bool colLeft = false;
	public bool colRight = false;

	public GameObject[] healthBar;

	public GameObject[] projectile;
	public int currentType;
    public GameObject cameraOBJ;
    public World worldScript;

    public GameObject endOBJ;
  

	int enemyDamage1 = 1;
	int countToNextHit;
	bool canBeHit;
	public int projectileSpeed;
	public int startHpCount;

	public float shootTime = 1f;
	public float shotInterval;
    public RaycastHit hit;

    public Ray ray;

    // Use this for initialization
    void Start () {

        cameraOBJ = GameObject.Find("Camera");
        ray = cameraOBJ.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        

        endOBJ = GameObject.FindGameObjectsWithTag("end");
       

		playerDestination = transform.position;
		mask = ~mask;

		countToNextHit = 0;
		currentType = 0;
		int startHp = 0;
		while (startHp < 6) 
		{
			healthBar [startHp].SetActive(true);
			startHp++;
		}

	}

	// Update is called once per frame
	void Update () {
		Vector2 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
	    
        if(Physics.Raycast(ray, out hit))
        {
          
            if(hit.collider.tag == "end")
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        if (health <= 0)
        {
         
            endOBJ.SetActive(true);
            Time.timeScale = 0;
        }
		if (countToNextHit == 0) 
		{
			canBeHit = true;
		}

		if (colliding == false)
		{
			if (Input.GetKey("w") && colUp == false)
			{
				playerDestination.y = playerDestination.y + playerDist;

			}
			if (Input.GetKey("s") && colDown == false)
			{
				playerDestination.y = playerDestination.y - playerDist;

			}
			if (Input.GetKey("a") && colLeft == false)
			{
				playerDestination.x = playerDestination.x - playerDist;

			}
			if (Input.GetKey("d") && colRight == false)
			{
				playerDestination.x = playerDestination.x + playerDist;

			}
			transform.position = Vector2.Lerp(transform.position, playerDestination, playerSpeed * Time.deltaTime);
		}

		if (Input.GetButton ("Fire1"))
		{
            shootTime -= Time.deltaTime;
            if (shootTime <= 0)
            {

           
                Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x,  mousePos.y));
                Vector2 myPos = new Vector2(transform.position.x, transform.position.y +1);
                Vector2 direction = target - myPos;
                direction.Normalize();
                Vector3 dir = new Vector3(mousePos.x, mousePos.y, 0);
                GameObject bullet = Instantiate(projectile[currentType], gameObject.transform.position, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
                bullet.GetComponent<Rigidbody>().velocity = direction * projectileSpeed;
                shootTime = 1f;
            }
				
		}
	}

	void FixedUpdate()
	{
		Vector3 fwd = transform.TransformDirection(Vector3.up);
		Debug.DrawRay(transform.position, fwd, Color.red);
		if (Physics.Raycast(transform.position, fwd, rayLength, mask.value))
		{
			colUp = true;
		}else
		{
			colUp = false;
		}

		Vector3 dwn = transform.TransformDirection(Vector3.down);
		Debug.DrawRay(transform.position, dwn, Color.red);
		if (Physics.Raycast(transform.position, dwn, rayLength, mask.value))
		{
			colDown = true;
		}
		else
		{
			colDown = false;
		}

		Vector3 left = transform.TransformDirection(Vector3.left);
		Debug.DrawRay(transform.position, left, Color.blue);
		if (Physics.Raycast(transform.position, left, rayLength, mask.value))
		{
			colLeft = true;
		}
		else
		{
			colLeft = false;
		}

		Vector3 right = transform.TransformDirection(Vector3.right);
		Debug.DrawRay(transform.position, right, Color.white);
		if (Physics.Raycast(transform.position, right, rayLength, mask.value))
		{
			colRight = true;
		}
		else
		{
			colRight = false;
		}
	}

    void OnCollisionEnter(Collision col)
    {
        print("hit");
		if (col.gameObject.tag == "wall")
		{
			colliding = true;
		}

		if (col.gameObject.tag == "enemy1")
		{
            print("hit");
			health = health - enemyDamage1;
			countToNextHit = enemyDamage1 * 10;
			healthBar [health].SetActive(false);
			Debug.Log ("enemyhitdamagetaken");
		}
		if (col.gameObject.tag == "heart")
		{
			healthBar [health].SetActive(true);
			health++;
			Destroy (col.gameObject);
		}
	}
}
