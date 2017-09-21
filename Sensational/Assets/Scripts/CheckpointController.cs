using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour 
{
    //player stepping on this will cause the CurrentCheckpoint in LevelGlobals to be set to this position

    public GameObject LevelGlobals;
    public GameObject SpawnPosition;

	// Use this for initialization
	void Start () 
    {
        //TimeState = GameObject.Find("LevelGlobals").GetComponent<LevelGlobals>().TimeStopped;

        LevelGlobals = GameObject.Find("LevelGlobals");
        //awnPosition = gameObject.GetComponentInChildren<Transform>();
    }
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "StandIgnore")
        {
            //if the player touches me
            LevelGlobals.GetComponent<LevelGlobals>().CurrentCheckpoint = SpawnPosition;
        }
    }
}
