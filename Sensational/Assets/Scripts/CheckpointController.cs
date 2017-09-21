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

    public bool FirstTimePlayerTouch = false;
    // Use this for initialization
    void Start()
    {
        //TimeState = GameObject.Find("LevelGlobals").GetComponent<LevelGlobals>().TimeStopped;

        LevelGlobals = GameObject.Find("LevelGlobals");
        //awnPosition = gameObject.GetComponentInChildren<Transform>();
        //CheckpointText = GameObject.Find("Canvas/CheckpointText");
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelGlobals.GetComponent<LevelGlobals>().TimeStopped == false)
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
            if (LevelGlobals.GetComponent<LevelGlobals>().TimeStopped == false)
            {
                CheckpointText.SetActive(true);

            }
            if (AmIALevelSwitchCheckpoint == true)
            {
                SceneManager.LoadScene(LevelToLoad);
            }
            //if the player touches me
            /*if(LevelGlobals.GetComponent<LevelGlobals>().CurrentCheckpoint != null)
            {
                LevelGlobals.GetComponent<LevelGlobals>().CurrentCheckpoint.GetComponent<CheckpointController>().AmITheActiveCheckpoint = false;
            }*/

            LevelGlobals.GetComponent<LevelGlobals>().CurrentCheckpoint = SpawnPosition;
            AmITheActiveCheckpoint = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "StandIgnore")
        {
            CheckpointText.SetActive(false);
            FirstTimePlayerTouch = true; //from now on this is true if the player touched this once.
        }
    }
}
