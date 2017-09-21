using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnagiSpawner : MonoBehaviour 
{
    private GameObject TimeGlobal;

    public GameObject[] HowManyKnifeButtons;
    public int CurrentNumberOfSolvedKnifeButtons;

    public GameObject[] HowManyOrbs;
    public int CurrentNumberOfSolvedOrbs;

    public bool ShouldISpawnAThing = true;
    public float SpawnDelay = 5.0f;
    public float SpawnCounter = 0f;
    public GameObject OnagiThatISpawned;

    public bool OrbsDone = false;
    public bool KnivesDone = false;

    public GameObject DespawnParticle;
    public GameObject OnagiToSpawn;

    // Use this for initialization
    void Start () 
    {
        TimeGlobal = GameObject.Find("LevelGlobals");
    }
	
	// Update is called once per frame
	void Update () 
    {
        CurrentNumberOfSolvedOrbs = 0;
        CurrentNumberOfSolvedKnifeButtons = 0;

        if(TimeGlobal.GetComponent<LevelGlobals>().TimeStopped == false)
        {
            if (ShouldISpawnAThing == true)
            {
                SpawnCounter += Time.deltaTime;
                if (SpawnCounter >= SpawnDelay)
                {
                    SpawnCounter = 0;
                    // GameObject StandPower = (GameObject)Instantiate(PreFabToMake, SpawnPos, transform.rotation);
                    OnagiThatISpawned = (GameObject)Instantiate(OnagiToSpawn, gameObject.transform.position, gameObject.transform.rotation);
                    ShouldISpawnAThing = false;
                }
            }

            if (OnagiThatISpawned == null)
            {
                ShouldISpawnAThing = true;
            }


        }


        //////////ALL THINGS ATTACHED TO ME ARE SOLVED////////////////////
        if (OrbsDone == true && KnivesDone == true)
        {
            //gameObject.GetComponent<AudioSource>().Play();
            GameObject StandPower = (GameObject)Instantiate(DespawnParticle, transform.position, transform.rotation);
            Destroy(gameObject);    
        }
        /////////////////////////////////////////////////////////////////////


        //check for number of solved knife buttons connected to me
		for(int i = 0; i < HowManyKnifeButtons.Length; i++)
        {
            if(HowManyKnifeButtons[i].GetComponent<KnifeButtonController>().Solved == true)
            {
                //print("knife number solved increment");
                CurrentNumberOfSolvedKnifeButtons++;
            }

            if(CurrentNumberOfSolvedKnifeButtons >= HowManyKnifeButtons.Length)
            {
                //do other stuff here
                //print("knife done");
                KnivesDone = true;
            }

            else
            {   
                KnivesDone = false;
            }

         
        }

        for (int i = 0; i < HowManyOrbs.Length; i++)
        {
            if (HowManyOrbs[i].GetComponent<OrbLogicAttempt>().GoalReached == true)
            {
                CurrentNumberOfSolvedOrbs++;
            }

            if (CurrentNumberOfSolvedOrbs >= HowManyOrbs.Length)
            {
                //do other stuff here

                OrbsDone = true;
            }

            else
            {
    
                OrbsDone = false;
            }
            
        }
    }
}
