using UnityEngine;
using System.Collections;

public class flee : MonoBehaviour {

	public float speed;
	public Vector2 destination;
	public bool collision;

	public float distance = 0.05f;
	public LayerMask mask = 1 << 8;
	public float rayLength = 0.1f;

	public bool colUp= false;
	public bool colDown = false;
	public bool colLeft = false;
	public bool colRight = false;

	public GameObject player;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Vector2 playerPosition = player.transform.position;

		if ((playerPosition.x * playerPosition.x) - (gameObject.transform.position.x * gameObject.transform.position.x) < 2) 
		{
			if (playerPosition.x > gameObject.transform.position.x) 
			{
				destination.x = destination.x - distance;
			} else {
				destination.x = destination.x + distance;
			}
		}else if (playerPosition.x > gameObject.transform.position.x) 
		{
			destination.x = destination.x + distance;
		} else {
			destination.x = destination.x - distance;
		}

		if ((playerPosition.y * playerPosition.y)- (gameObject.transform.position.y * gameObject.transform.position.y)< 2) 
		{
			if (playerPosition.y > gameObject.transform.position.y)
			{
				destination.y = destination.y - distance;
			} else {
				destination.y = destination.y + distance;
			}
		}else if (playerPosition.y > gameObject.transform.position.y) 
		{
			destination.y = destination.y + distance;
		} else {
			destination.y = destination.y - distance;
		}
		transform.position = Vector2.Lerp(transform.position, destination, speed * Time.deltaTime);
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
}
