using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject worldOBJ;
    public World worldScript;
    public int sTimer;
    public int round;
    public int divFive;
    public int rDivFive;
    public int fiveRound;
    public int spawn = 1;
    public bool spawnable = true;
    public bool roundInc = true;
    public float spawnDelay = 0;

    public GameObject basicPrefab;
    GameObject basicPrefabClone;

    
	// Use this for initialization
	void Start ()
    {
        worldOBJ = GameObject.Find("_World");
        worldScript = worldOBJ.GetComponent<World>();
        //basicPrefabClone = Instantiate(basicPrefab, transform.position, Quaternion.identity) as GameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {
        divFive = sTimer % 5;
        rDivFive = round % 5;
        if(rDivFive == 0 && roundInc == true)
        {
            fiveRound++;
            roundInc = false;
        }

        sTimer = worldScript.timer;
        if (divFive == 0 && spawnable == true)
        {
           spawnDelay -= Time.deltaTime;
            if (spawnDelay <= 0)
            {
                spawnDelay = 0;
            }
            if (spawnDelay == 0)
            {
                basicPrefabClone = Instantiate(basicPrefab, transform.position, Quaternion.identity) as GameObject;
                spawn--;
                spawnDelay = 0.2f;
            }
            
           
            if (spawn == 0)
            {
                spawnable = false;
            }
        }
        if(divFive !=0 && spawnable == false)
        {
            spawn = fiveRound +1;
            spawnable = true;
            round++;
            roundInc = true;
        }
    }
}
