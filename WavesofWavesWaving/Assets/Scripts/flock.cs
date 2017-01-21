using UnityEngine;
using System.Collections;

public class flock : MonoBehaviour {

	public float speed = 10;
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

	public string ally;
	public GameObject closestAlly;
	public bool closeAlly;

	// Use this for initialization
	void Start () {
		ally = gameObject.tag;
	}

	void FindClosestAlly()
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag (ally);
		GameObject closest = null;
		float dist = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach(GameObject go in gos)
		{
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < dist) 
			{
				closest = go;
				dist = curDistance;
			}
			closestAlly = closest;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		FindClosestAlly ();

		if ((Mathf.Sqrt(closestAlly.transform.position.x*closestAlly.transform.position.x + closestAlly.transform.position.y*closestAlly.transform.position.y) - Mathf.Sqrt(gameObject.transform.position.x*gameObject.transform.position.x + gameObject.transform.position.y*gameObject.transform.position.y)) > 3.0f) 
		{
			Vector2 playerPosition = closestAlly.transform.position;

			if (playerPosition.x > gameObject.transform.position.x) 
			{
				destination.x = destination.x + distance;
			} else {
				destination.x = destination.x - distance;
			}
			if (playerPosition.y > gameObject.transform.position.y) 
			{
				destination.y = destination.y + distance;
			} else {
				destination.y = destination.y - distance;
			}
		} 
		else 
		{
			Vector2 playerPosition = player.transform.position;

			if (playerPosition.x > gameObject.transform.position.x) 
			{
				destination.x = destination.x + distance;
			} else {
				destination.x = destination.x - distance;
			}
			if (playerPosition.y > gameObject.transform.position.y) 
			{
				destination.y = destination.y + distance;
			} else {
				destination.y = destination.y - distance;
			}
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
