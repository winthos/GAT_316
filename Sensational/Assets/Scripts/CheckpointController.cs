using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CheckpointController : MonoBehaviour 
{
    //player stepping on this will cause the CurrentCheckpoint in LevelGlobals to be set to this position

    public GameObject LevelGlobals;
    public GameObject SpawnPosition;

    public bool AmITheActiveCheckpoint = false;

    public GameObject IsThisActive;

    public bool AmIALevelSwitchCheckpoint = false;
    public string LevelToLoad = null;
    public GameObject CheckpointText;

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
        if(LevelGlobals.GetComponent<LevelGlobals>().TimeStopped == false)
        {
            if (AmITheActiveCheckpoint == true)
            {
                IsThisActive.SetActive(true);
            }

            if (AmITheActiveCheckpoint == false)
            {
                IsThisActive.SetActive(false);
            }
        }

	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "StandIgnore")
        {
            if(AmIALevelSwitchCheckpoint == true)
            {
                SceneManager.LoadScene(LevelToLoad);
            }
            //if the player touches me
            /*if(LevelGlobals.GetComponent<LevelGlobals>().CurrentCheckpoint != null)
            {
                LevelGlobals.GetComponent<LevelGlobals>().CurrentCheckpoint.GetComponent<CheckpointController>().AmITheActiveCheckpoint = false;
            }*/
            if(LevelGlobals.GetComponent<LevelGlobals>().TimeStopped == false)
            {
                LevelGlobals.GetComponent<LevelGlobals>().CurrentCheckpoint = SpawnPosition;

                if(AmITheActiveCheckpoint != true)
                {
                    AmITheActiveCheckpoint = true;
                    CheckpointText.SetActive(true);
                }
               // AmITheActiveCheckpoint = true;
               // CheckpointText.SetActive(true);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "StandIgnore")
            CheckpointText.SetActive(false);
    }
}
