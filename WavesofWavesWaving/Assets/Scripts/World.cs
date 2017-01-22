using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {

    public float timeFloat = 0;
    public int timer = 0;
    public bool started;
    public int round;
    public float delay;
    public int roundInc;
    public bool inc = false;
    

    public GameObject startObj;
    public StartScript startScript;

    public GameObject bSpawner1;
    public GameObject bSpawner2;
    public GameObject bSpawner3;
    public GameObject bSpawner4;

    public GameObject wSpawner;

    public GameObject cSpawner;

    // Use this for initialization
    void Start ()
    {
        startObj = GameObject.Find("Start");
        startScript = startObj.GetComponent<StartScript>();

        bSpawner1 = GameObject.Find("BasicSpawnerL");
        bSpawner1.SetActive(false);
        bSpawner2 = GameObject.Find("BasicSpawnerT");
        bSpawner2.SetActive(false);
        bSpawner3 = GameObject.Find("BasicSpawnerR");
        bSpawner3.SetActive(false);
        bSpawner4 = GameObject.Find("BasicSpawnerB");
        bSpawner4.SetActive(false);

    }
	
	// Update is called once per frame
	void Update ()
    {

        int roundDiv = round % 5;
        if(GameObject.Find("Start") == null)
        {
            started = true;
            timeFloat += Time.deltaTime;
            timer = Mathf.FloorToInt(timeFloat);
            roundInc = timer % 5;
        }
        if(roundInc == 0 && inc == true)
        {
            round++;
            inc = false;
        }
        else if(roundInc != 0 && inc == false)
        {
            inc = true;
        }
        if(started == true)
        {
            bSpawner1.SetActive(true);
        }
        if (round >= 5)
        {
            bSpawner2.SetActive(true);
        }
        if (round >= 10)
        {
            bSpawner3.SetActive(true);
        }
        if (round >= 15)
        {
            bSpawner4.SetActive(true);
        }
    }
}
