using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSpawnerController : MonoBehaviour 
{
    public GameObject LevelGlobals;
    public float SpawnDelay = 2.0f;
    public float SpawnCounter = 0.0f;

    public float KnifeSpeed = 20f;

    public GameObject KnifePrefab;
    // Use this for initialization
    void Start () 
    {
        LevelGlobals = GameObject.Find("LevelGlobals");
    }
	
	// Update is called once per frame
	void Update () 
    {
		if(LevelGlobals.GetComponent<LevelGlobals>().TimeStopped == false)
        {
            SpawnCounter += Time.deltaTime;
            if(SpawnCounter >= SpawnDelay)
            {
                GameObject StandPower = (GameObject)Instantiate(KnifePrefab, transform.position, transform.rotation);
                StandPower.GetComponent<Rigidbody>().velocity = transform.forward * KnifeSpeed;
                SpawnCounter = 0;
            }
        }
	}
}
