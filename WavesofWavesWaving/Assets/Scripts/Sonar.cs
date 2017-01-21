using UnityEngine;
using System.Collections;

public class Sonar : MonoBehaviour {

    public float radius;
    public SphereCollider myCollider;
    public bool sonar = false;
	// Use this for initialization
	void Start () {
       myCollider = transform.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Input.GetKeyDown("e") && sonar == false)
        {
            sonar = true;
        }

        if (sonar == true)
        {
            print("a");
            myCollider.radius = myCollider.radius + 0.2f;
            if (myCollider.radius > 10f)
            {
                myCollider.radius = 0.1f;
                sonar = false;
            }
        }
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "enemy1")
        {
            print("3");
           SpriteRenderer spriteRenderer = col.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = true;
        }
       
    }
}
