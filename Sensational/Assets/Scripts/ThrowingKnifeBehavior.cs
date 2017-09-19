﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnifeBehavior : MonoBehaviour 
{
    private GameObject TimeGlobal;
    private Rigidbody MyBody;
    private Vector3 OldVelocity;
    public float ForwardSpeed = 10;
    public Vector3 ForwardDirection;
    public GameObject PreFabToMake;
    private float DespawnTimer = 0.7f;
    private float lerpToStopCounter = 0f;
    private float slowdownSpeed = 0.3f;
    private bool stoptimeLerpdone = false;
    private bool normaltimeLerpdone = false;

    private bool timeNotStoppedYet = false;
    // Use this for initialization
    void Start()
    {
        TimeGlobal = GameObject.Find("LevelGlobals");
        MyBody = GetComponent<Rigidbody>();
        OldVelocity = MyBody.velocity;
        // StandBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //if time is stopped do these
        if(TimeGlobal.GetComponent<LevelGlobals>().TimeStopped == true)
        {
            if (lerpToStopCounter >= slowdownSpeed)
            {
                stoptimeLerpdone = true;
                MyBody.velocity = OldVelocity / TimeGlobal.GetComponent<LevelGlobals>().TimeSlowScale;
                lerpToStopCounter = 0f;
                return;
            }

            if (stoptimeLerpdone == false)
            {
                //counter that is incremented with time / how long it takes to get to zero
                MyBody.velocity = Vector3.Lerp(OldVelocity, Vector3.zero, lerpToStopCounter / slowdownSpeed);
                lerpToStopCounter += Time.deltaTime;
            }
        }

        //if time resumes do these
        if (TimeGlobal.GetComponent<LevelGlobals>().TimeStopped == false)
        {
            //hey it's time to go away.....
            DespawnTimer -= Time.deltaTime;
            if (DespawnTimer <= 0)
            {
                //spawn in the hitspark particle here
                AudioSource audio = GameObject.Find("StandInSound").GetComponent<AudioSource>();
                audio.Play();
                GameObject StandPower = (GameObject)Instantiate(PreFabToMake, transform.position, transform.rotation);
                Destroy(gameObject);
            }

            if (timeNotStoppedYet == false)
            {
                MyBody.velocity = OldVelocity;
            }

            if (timeNotStoppedYet == true)
            {
                stoptimeLerpdone = false;
                if (lerpToStopCounter >= slowdownSpeed)
                {
                    normaltimeLerpdone = true;
                    MyBody.velocity = OldVelocity;
                    lerpToStopCounter = 0f;
                    return;
                }

                // MyBody.velocity = OldVelocity;
                if (normaltimeLerpdone == false)
                {
                    MyBody.velocity = Vector3.Lerp(Vector3.zero, OldVelocity, lerpToStopCounter / slowdownSpeed);
                    lerpToStopCounter += Time.deltaTime;
                }

            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        //print("collision is happening");
        if (col.gameObject.tag == "StandTouch")
        {
            //spawn explosion particle here?
            AudioSource audio = GameObject.Find("StandInSound").GetComponent<AudioSource>();
            audio.Play();
            GameObject StandPower = (GameObject)Instantiate(PreFabToMake, transform.position, transform.rotation);

            if (col.gameObject.name == "Projectile")
            {
                //Destroy(col.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
