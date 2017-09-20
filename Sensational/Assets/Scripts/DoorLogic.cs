using UnityEngine;
using System.Collections;

public class DoorLogic : MonoBehaviour 
{
    private GameObject TimeGlobal;
    public GameObject WhereAreYou; //this is for where the orb puzzle is
    public GameObject PreFabToMake;

    public bool AmIAKnifeDoor = false; //if you are a knife door, need to have an array of how many knife buttons are attached to me.
    public GameObject[] HeavensDoor;
    public int TotalKnifeButtons; //set to length of array, so how many buttons are linked to this door
    public int HowManyKnifeButtonsAreSolved;

    // Use this for initialization
    void Start () 
	{
        TimeGlobal = GameObject.Find("LevelGlobals");
        TotalKnifeButtons = HeavensDoor.Length;
    }
	
	// Update is called once per frame
	void Update () 
	{
        if (TimeGlobal.GetComponent<LevelGlobals>().TimeStopped == true)
        {
            return;
        }

        //we are in normal time
        if (TimeGlobal.GetComponent<LevelGlobals>().TimeStopped == false)
        {
            if(AmIAKnifeDoor == false)
            {
                if (WhereAreYou.GetComponent<OrbLogicAttempt>().GoalReached == true)
                {
                    GameObject StandPower = (GameObject)Instantiate(PreFabToMake, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
            }

            //we are in normal time and I am connected to knife buttons
            if(AmIAKnifeDoor == true)
            {
                for(int i = 0; i < HeavensDoor.Length; i++)
                {
                    //if door at this index is solved
                    if(HeavensDoor[i].GetComponent<KnifeButtonController>().Solved == true)
                    {
                        if(HeavensDoor[i].GetComponent<KnifeButtonController>().Solved == true)
                        {
                            HowManyKnifeButtonsAreSolved++;
                        }
                    }
                }

                if(HowManyKnifeButtonsAreSolved >= TotalKnifeButtons)
                {
                    //destroy the door and keep goin
                    GameObject StandPower = (GameObject)Instantiate(PreFabToMake, transform.position, transform.rotation);
                    Destroy(gameObject);
                }

                HowManyKnifeButtonsAreSolved = 0;
            }

        }
    }
}
