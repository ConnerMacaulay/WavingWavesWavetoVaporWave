using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int damage;
	public int countToNextHit;



	// Use this for initialization
	void Start () {
	
		damage = 1;
		countToNextHit = 0;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "player")
		{
			
		}
	}
}
