using UnityEngine;
using System.Collections;

public class Sonar : MonoBehaviour {

    public float radius;
    public SphereCollider myCollider;
    public bool sonar = false;
    public GameObject sonarWave;
     
    // Use this for initialization
    void Start () {
       myCollider = transform.GetComponent<SphereCollider>();
        sonarWave = GameObject.Find("SonarWave");

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

           SpriteRenderer spriteRenderer = col.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = true;
        }
       
    }
}
