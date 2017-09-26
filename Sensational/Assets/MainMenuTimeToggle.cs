using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class MainMenuTimeToggle : MonoBehaviour 
{
    public GameObject LevelGlobals;
    public float counter;

    private GameObject WhereIsThePlayerOhMyGod;

    public GameObject TitleNormal;
    public GameObject TitlePaused;
    // Use this for initialization
    void Start () 
    {
        counter = Random.Range(2.0f, 6.0f);
        WhereIsThePlayerOhMyGod = GameObject.Find("FPSController/FirstPersonCharacter");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
	
	// Update is called once per frame
	void Update () 
    {
        counter -= Time.deltaTime;
        if (LevelGlobals.GetComponent<LevelGlobals>().TimeStopped == false)
        {
            TitlePaused.SetActive(false);
            TitleNormal.SetActive(true);
        }

        else if (LevelGlobals.GetComponent<LevelGlobals>().TimeStopped == true)
        {
            TitlePaused.SetActive(true);
            TitleNormal.SetActive(false);
        }


            if (counter <= 0)
        {
            if(LevelGlobals.GetComponent<LevelGlobals>().TimeStopped == false)
            {
                LevelGlobals.GetComponent<LevelGlobals>().TimeStopped = true;
                //WhereIsThePlayerOhMyGod.GetComponent<Grayscale>().enabled = true;
                //WhereIsThePlayerOhMyGod.GetComponent<Grayscale>().textureRamp = ColorGreyscale;

            }

            else if (LevelGlobals.GetComponent<LevelGlobals>().TimeStopped == true)
            {
                LevelGlobals.GetComponent<LevelGlobals>().TimeStopped = false;

            }

            counter = Random.Range(0.8f, 4.0f);
        }
	}


    /*
     *         if (Input.GetMouseButtonDown(1) && TimeStopped == false && StopCounter != 4)
        {
            TimeStopped = true;
          //  WhereIsThePlayerOhMyGod.GetComponent<TiltShift>().enabled = true;
            WhereIsThePlayerOhMyGod.GetComponent<Grayscale>().enabled = true;
            WhereIsThePlayerOhMyGod.GetComponent<Grayscale>().textureRamp = ColorGreyscale;
            TimeStopCount++;
           // StopCounter++;
            /*
            if (StopCounter == 1)
            {
                GameObject.Find("Canvas/cooldown1").GetComponent<Image>().enabled = true;
            }
            if (StopCounter == 2)
            {
                GameObject.Find("Canvas/cooldown2").GetComponent<Image>().enabled = true;
            }
            if (StopCounter == 3)
            {
                GameObject.Find("Canvas/cooldown3").GetComponent<Image>().enabled = true;
            }
            if (StopCounter == 4)
            {
                GameObject.Find("Canvas/cooldown4").GetComponent<Image>().enabled = true;
            }
}
        else if(Input.GetMouseButtonDown(1) && TimeStopped == true)
        {
            TimeStopped = false;
        }
     * 
     * 
     * 
     * 
     * */
}
