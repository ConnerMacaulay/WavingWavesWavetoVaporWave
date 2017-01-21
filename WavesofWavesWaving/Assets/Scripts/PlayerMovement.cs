using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

	int enemyDamage1 = 1;
	int countToNextHit;
	bool canBeHit;
	public int projectileSpeed;
	public int startHpCount;

	public float shootTime;
	public float shotInterval;

	// Use this for initialization
	void Start () {

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
		Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
		lookPos = lookPos - transform.position;
		float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

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

		if (Input.GetButtonDown ("Fire1"))
		{
			if (shootTime > 10) 
			{

				Vector3 playerPos = gameObject.transform.position;
				Vector3 playerDirection = gameObject.transform.forward;
				Quaternion playerRotation = gameObject.transform.rotation;
				float spawnDistance = 10;

				Vector3 spawnPos = playerPos + playerDirection*spawnDistance;

				//Instantiate(Resources.Load(projectile[currentType]), spawnPos, playerRotation );

				Debug.Log (lookPos);
				GameObject bullet = Instantiate (projectile [currentType], gameObject.transform.position, Quaternion.Euler(0f, 0f, 0f)) as GameObject;

				//GameObject bullet = Instantiate (projectile[currentType]), spawnPos, playerRotation)) as GameObject;


				Vector3 dir = new Vector3 (mousePos.x, mousePos.y, 0);
				bullet.GetComponent<Rigidbody> ().AddForce (dir.normalized * projectileSpeed, ForceMode.Impulse);
			}
			shootTime = Time.time + shotInterval;		
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

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "wall")
		{
			colliding = true;
		}

		if (col.gameObject.tag == "enemy1")
		{
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
