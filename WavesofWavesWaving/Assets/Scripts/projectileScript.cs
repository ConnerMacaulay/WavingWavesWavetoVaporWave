using UnityEngine;
using System.Collections;

public class projectileScript : MonoBehaviour {

	int counter;

	// Use this for initialization
	void Start () {
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (counter == 100) 
		{
			Destroy (gameObject);
		}
		counter++;
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "enemy1") 
		{
			Debug.Log ("hit enemy1");
			Destroy (col.gameObject);
			Destroy (gameObject);
		}
	}
}
