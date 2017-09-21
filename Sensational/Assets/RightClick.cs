using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClick : MonoBehaviour
{

    public GameObject RIGHTCLICK;
    //public GameObject MOUSE;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "StandIgnore")
        {
            //if the player comes in here
            RIGHTCLICK.SetActive(true);
           // MOUSE.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "StandIgnore")
        {
            //if the player comes in here
            RIGHTCLICK.SetActive(false);
           // MOUSE.SetActive(false);
        }
    }
}