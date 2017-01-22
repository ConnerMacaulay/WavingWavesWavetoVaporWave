using UnityEngine;
using System.Collections;

public class SonarWave : MonoBehaviour {

    //   public GameObject player;
       public bool waveOut = false;
    //   public bool waveIn = true;
    //   public Transform pTrans;
    //// Use this for initialization
    //void Start ()
    //   {
    //       player = GameObject.Find("Player");
    //       pTrans = player.GetComponent<Transform>();
    //}

    //// Update is called once per frame
    //void Update ()
    //   {
    //       if (waveOut == true)
    //       {
    //           print("2");
    public Vector3 trans; 
    //           Vector3 transP = pTrans.localPosition;
    //           trans.z = trans.z+0.001f;
    //           transform.position = transP - trans;
    //       }

    //       if (waveIn == true)
    //       { }	
    //}

    public float m_speed;

    void Update()
    {
        trans = transform.localPosition;
       
        if (Input.GetKeyUp("e"))
        {
            Scan();
        }
        
    }
    void Scan()
        {
            print(trans.z);
            if (waveOut == true)
            {
                if (trans.z >= -15)
                {
                    transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));
                }
                if (trans.z <= -15)
                {
                    waveOut = false;
                }
            }
             if (waveOut == false)
            {
                if (trans.z <= -0.5)
                {
                    transform.Translate(new Vector3(0, 0, m_speed * Time.deltaTime));
                }

                if (trans.z >= -0.5)
                {
                    waveOut = true;
                }
            }
     }
}
