using UnityEngine;
using System.Collections;

public class SonarWave : MonoBehaviour {

   
       public bool waveOut = false;
    public bool loop = false;
    public float delay = 0;
    public Vector3 trans; 
   

    public float m_speed;

    void Update()
    {
        trans = transform.localPosition;
       
        if (Input.GetKeyDown("e") && delay <= 0)
        {
            loop = true;
            waveOut = true;
            delay = 1f;
           
        }

        if (loop == true)
        {
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
            else if (waveOut == false)
            {
                if (trans.z <= -0.5)
                {
                    transform.Translate(new Vector3(0, 0, m_speed * Time.deltaTime));
                }
                if(delay>0)
                {
                    delay -= Time.deltaTime;
                }
                else if (trans.z >= -0.5)
                {
                   loop = false;
                   
                }
                
               
            }
        }
    }
}
