using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDandMOUSE : MonoBehaviour 
{

    public GameObject WASD;
    public GameObject MOUSE;
	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "StandIgnore")
        {
            //if the player comes in here
            WASD.SetActive(true);
            MOUSE.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "StandIgnore")
        {
            //if the player comes in here
            WASD.SetActive(false);
            MOUSE.SetActive(false);
        }
    }
}
