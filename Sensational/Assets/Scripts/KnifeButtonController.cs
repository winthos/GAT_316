using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeButtonController : MonoBehaviour 
{
    private GameObject TimeGlobal;
    public GameObject[] Pips; //keep track of all five pips
    public int NumberOfKnivesThatHitMeSoFar = 0;

    public bool ShouldIBeCountingDown = false;
    public float TimeBeforeReset = 1.0f; //after the first knife hits, begin ticking this down. If at zero reset
    public float Counter = 0f;

    public bool Solved = false;

    public float BiggerReset = 5.0f;
    public float BiggerResetCounter = 0f;

    public GameObject ShortResetBar;
    public GameObject LongResetBar;

    //public bool ColorDoThisOnce = false;
    //
    // Use this for initialization
    void Start () 
    {
        TimeGlobal = GameObject.Find("LevelGlobals");
        Counter = TimeBeforeReset;
       // gameObject.GetComponent<Renderer>().material = Colors[0];
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (Solved == true)
        {
            //print("feedback that it is solved");

            
        }

    ////////////////PUZZLE SOLVED STUFF////////

        if (NumberOfKnivesThatHitMeSoFar >= Pips.Length)
        {
            ShouldIBeCountingDown = false;
            //do the stuff here
            //add the particle effect play
            //trigger the correct door
            Solved = true;

            if (TimeGlobal.GetComponent<LevelGlobals>().TimeStopped == false)
            {
                //this is the reset for the whole thing after we have solved the puzzle
                BiggerResetCounter += Time.deltaTime;
                Vector3 newVec = new Vector3(LongResetBar.transform.localScale.x, LongResetBar.transform.localScale.y, (BiggerReset - BiggerResetCounter) / BiggerReset);
                LongResetBar.transform.localScale = newVec;

                if (BiggerResetCounter >= BiggerReset)
                {
                    LongResetBar.transform.localScale = new Vector3(LongResetBar.transform.localScale.x, LongResetBar.transform.localScale.y, 1);
                    ShortResetBar.transform.localScale = new Vector3(ShortResetBar.transform.localScale.x, ShortResetBar.transform.localScale.y, 1);
                    ShouldIBeCountingDown = false;
                    NumberOfKnivesThatHitMeSoFar = 0;
                    Counter = TimeBeforeReset;
                    for (int i = 0; i < Pips.Length; i++)
                    {
                        Pips[i].SetActive(true);
                    }
                    Solved = false;
                    //ColorDoThisOnce = false;
                    //gameObject.GetComponent<Renderer>().material = Colors[0];
                    BiggerResetCounter = 0f;
                }
            }


            return;
        }

    //////////////////////////////////////
            

        //////////short reset before solved here////////////
        if(ShouldIBeCountingDown == true)
        {
            if (TimeGlobal.GetComponent<LevelGlobals>().TimeStopped == false)
            {
                Counter -= Time.deltaTime;

                //short bar reset
                Vector3 newVec = new Vector3(ShortResetBar.transform.localScale.x, ShortResetBar.transform.localScale.y, Counter / TimeBeforeReset);
                ShortResetBar.transform.localScale = newVec;
            }


            //ok it's time to reset everything
            if(Counter <= 0)
            {
                ShortResetBar.transform.localScale = new Vector3(ShortResetBar.transform.localScale.x, ShortResetBar.transform.localScale.y, 1);
                ShouldIBeCountingDown = false;
                NumberOfKnivesThatHitMeSoFar = 0;
                Counter = TimeBeforeReset;
                //ColorDoThisOnce = false;
                //gameObject.GetComponent<Renderer>().material = Colors[0];
                for (int i = 0; i < Pips.Length; i++)
                {
                    Pips[i].SetActive(true);
                }
            }
        }
        ////////////////////////////////////////////////
        
        //time is normal
        if (TimeGlobal.GetComponent<LevelGlobals>().TimeStopped == false)
        {

        }

        //time is stopped
        if (TimeGlobal.GetComponent<LevelGlobals>().TimeStopped == true)
        {

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "DoYouUnderstand")
        {
            if (NumberOfKnivesThatHitMeSoFar < Pips.Length)
            {
                //print("A Knife Hit Me");
                NumberOfKnivesThatHitMeSoFar += 1;
                Pips[NumberOfKnivesThatHitMeSoFar - 1].SetActive(false);
                ShouldIBeCountingDown = true;
            }
        }
    }
}
