using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterSpawnerController : MonoBehaviour
{

    public GameObject LevelGlobals;
    public float SpawnDelay = 2.0f;
    public float SpawnCounter = 0.0f;
    public GameObject SpawnPoint = null;
    //public float KnifeSpeed = 20f;

    public GameObject Prefab;

    public GameObject ThingISpawnedINeedToKeepTrackOf = null;

    public bool DontsPawnRightNow = false;
    // Use this for initialization
    void Start()
    {
        LevelGlobals = GameObject.Find("LevelGlobals");
    }

    // Update is called once per frame
    void Update()
    {

        if (ThingISpawnedINeedToKeepTrackOf == null)
        {
            //if the turret is gone, then go ahead and start countdown for another

            if (LevelGlobals.GetComponent<LevelGlobals>().TimeStopped == false && DontsPawnRightNow == false)
            {
                SpawnCounter += Time.deltaTime;
                if (SpawnCounter >= SpawnDelay)
                {
                    ThingISpawnedINeedToKeepTrackOf = (GameObject)Instantiate(Prefab, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                    // StandPower.GetComponent<Rigidbody>().velocity = transform.forward * KnifeSpeed;

                    //if(ThingISpawnedINeedToKeepTrackOf == null)
                    SpawnCounter = 0;
                    DontsPawnRightNow = true;
                }
            }
        }

        if (ThingISpawnedINeedToKeepTrackOf == null)
        {
            //if we have spawned a turret, don't be spawning more yet
            DontsPawnRightNow = false;

        }

    }
}
