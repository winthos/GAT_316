using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifePickupController : MonoBehaviour 
{
    public GameObject knives;
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
        if (other.gameObject.tag == "StandIgnore")
        {
            other.gameObject.GetComponentInChildren<StandActivator>().enabled = true;
            knives.SetActive(false);
        }
    }
}
