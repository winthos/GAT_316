using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidConnectorLogic : MonoBehaviour {

    public KnifeButtonController KnifeButton;
    public GameObject SolidPart;

	// Use this for initialization
	void Start () 
    {
        KnifeButton = gameObject.GetComponentInParent<Transform>().GetComponentInParent<KnifeButtonController>();	
	}
	
	// Update is called once per frame
	void Update () 
    {
		if(KnifeButton.Solved == true)
        {
            SolidPart.SetActive(true);
        }

        if(KnifeButton.Solved == false)
        {
            SolidPart.SetActive(false);
        }
	}
}
