using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneController : MonoBehaviour 
{
    public GameObject LevelGlobals;
    private DamageFlashController DamageFlashOnCanvas;

    // Use this for initialization
    void Start () 
    {
        LevelGlobals = GameObject.Find("LevelGlobals");
        DamageFlashOnCanvas = GameObject.Find("Canvas/DamageFlash").GetComponent<DamageFlashController>();
    }
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "StandIgnore")
        {
            //if the player touched me, reset their position
            //LevelGlobals.GetComponent<LevelGlobals>().CurrentCheckpoint = gameObject;
            other.gameObject.GetComponent<Transform>().position = LevelGlobals.GetComponent<LevelGlobals>().CurrentCheckpoint.transform.position;
          //  other.gameObject.GetComponent<Transform>().forward = LevelGlobals.GetComponent<LevelGlobals>().CurrentCheckpoint.transform.forward;
            DamageFlashOnCanvas.EnableScreen();
        }
    }
}
