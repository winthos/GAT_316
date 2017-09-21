using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHIFT : MonoBehaviour
{

    public GameObject SHIFTBUTTON;
    public GameObject SPRINT;
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
            SHIFTBUTTON.SetActive(true);
            SPRINT.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "StandIgnore")
        {
            //if the player comes in here
            SHIFTBUTTON.SetActive(false);
            SPRINT.SetActive(false);

        }
    }
}

