﻿using UnityEngine;
using System.Collections;

public class Room4Data : MonoBehaviour 
{

    private float TimeSpentInThisRoom = 0.0f;

    private float TimeSpentInStoppedTimeInThisRoom = 0.0f;

    private float NormalTimeSpentInThisRoom = 0.0f;

    private int TimesTimeHasStoppedInThisRoom = 0;

    private int ShotsFiredInThisRoom = 0;

    public bool StartUpdatingTime = false;
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (StartUpdatingTime == true)
        {
            TimeSpentInThisRoom += Time.deltaTime;
            gameObject.GetComponent<DataNStuff>().UpdateTimeInRoom4(TimeSpentInThisRoom);

            //get time spent in normal time
            NormalTimeSpentInThisRoom = TimeSpentInThisRoom - TimeSpentInStoppedTimeInThisRoom;
            gameObject.GetComponent<DataNStuff>().UpdateNormalTimeInRoom4(NormalTimeSpentInThisRoom);

            if (GameObject.Find("LevelGlobals").GetComponent<LevelGlobals>().TimeStopped == true)
            {
                TimeSpentInStoppedTimeInThisRoom += Time.deltaTime;
                gameObject.GetComponent<DataNStuff>().UpdateStoppedTimeInRoom4(TimeSpentInStoppedTimeInThisRoom);
            }

            //if time is not stopped and you press right click
            if (GameObject.Find("LevelGlobals").GetComponent<LevelGlobals>().TimeStopped == true && Input.GetMouseButtonUp(1) == true)
            {
                TimesTimeHasStoppedInThisRoom += 1;
                gameObject.GetComponent<DataNStuff>().UpdateNumberOfTimeStopsInRoom4(TimesTimeHasStoppedInThisRoom);
            }

            //ok lets track shots now, while in this room and you left click increment this counter
            if (Input.GetMouseButtonDown(0) == true && GameObject.Find("FirstPersonCharacter").GetComponent<StandActivator>().ReadyToActivate == true)
            {
                ShotsFiredInThisRoom += 1;
                gameObject.GetComponent<DataNStuff>().UpdateNumberOfShotsInRoom4(ShotsFiredInThisRoom);
            }
        }

      
    }
}