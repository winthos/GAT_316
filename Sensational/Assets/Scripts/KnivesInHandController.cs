using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnivesInHandController : MonoBehaviour 
{
    private GameObject TimeGlobal;
    public Transform startMarker;
    public Transform endMarker;
    public float speed = 0.5F;
    private float startTime;
    private float journeyLength; //how far to move remaining
    //public int NumberOfKnives;
    public GameObject StandActivator;

    private bool dothisonce = false;

    public GameObject[] KnifeHandles;
    public GameObject[] KnifeBlades;
    void Start()
    {
        TimeGlobal = GameObject.Find("LevelGlobals");
        //startTime = Time.time;
        //journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        //StandActivator =.GetComponent<StandActivator>().NumberOfKnivesLeft;
        //transform.position = startMarker.position;
    }
    void Update()
    {
        //if time is flowing
        if (TimeGlobal.GetComponent<LevelGlobals>().TimeStopped == false)
        {
            /*float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
            print(startMarker.position);
            */
            //if we have reloaded and have 10 knives either from teh start or from the reload
            if (StandActivator.GetComponent<StandActivator>().NumberOfKnivesLeft == 10)
            {
                if (dothisonce == false)
                {
                    transform.position = startMarker.position;
                    dothisonce = true;
                }

                if (transform.position != endMarker.position)
                {
                    transform.position = Vector3.MoveTowards(transform.position, endMarker.position, speed * Time.deltaTime);
                }

            }
        }

        if (TimeGlobal.GetComponent<LevelGlobals>().OnagiTimeStopped == true)
        {
            for(int i = 0; i < KnifeHandles.Length; i++)
            {
                KnifeHandles[i].GetComponent<ColorChanger>().enabled = true;
                KnifeBlades[i].GetComponent<ColorChanger>().enabled = true;
            }
        }
    }

    public void Reset()
    {
        dothisonce = false;
    }
}
