using UnityEngine;
using System.Collections;

public class TimeStopParticlesOnMe : MonoBehaviour 
{
    private bool TimeState;
    private ParticleSystem ParticleThing;

    bool dothisonce = false;

    //this function seems to grab any particle system on the object and plays it when time is normal, and pauses it when time is stopped. sure
	// Use this for initialization
	void Start () 
	{
        TimeState = GameObject.Find("LevelGlobals").GetComponent<LevelGlobals>().TimeStopped;
        ParticleThing = GetComponent<ParticleSystem>();
        ParticleThing.Play();
    }
	
	// Update is called once per frame
	void Update () 
	{
        TimeState = GameObject.Find("LevelGlobals").GetComponent<LevelGlobals>().TimeStopped;
       // print(TimeState);
        if (TimeState == false && dothisonce == false)
        {
            
            GetComponent<ParticleSystem>().Play();
            dothisonce = true;
        }

        if (TimeState == true && dothisonce == true)
        {
            //return;
            GetComponent<ParticleSystem>().Pause();
            
            dothisonce = false;
        }



    }
}
