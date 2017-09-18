using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickOnPlatform : MonoBehaviour
{
    public GameObject PlatformEmpty;

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
            print("parent trap");
            other.gameObject.transform.SetParent(PlatformEmpty.transform, true);
            //other.gameObject.transform.parent = PlatformEmpty.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "StandIgnore")
        {
            print("parent trap");
            other.gameObject.transform.parent = null;
        }
    }
}
