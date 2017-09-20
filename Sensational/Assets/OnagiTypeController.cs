using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class OnagiTypeController : MonoBehaviour 
{
    private GameObject WhereIsThePlayerOhMyGod;
    private GameObject TimeGlobal;

    public Texture NormalGreyscale;
    public Texture ColorGreyscale;
    private float greyscalecounter = 0f;
    public Rigidbody rb;
    public float thrust = 1;

    public GameObject PlayerSpawn;
    private SphereCollider MySphere;

    // Use this for initialization
    void Start () 
    {
        WhereIsThePlayerOhMyGod = GameObject.Find("FPSController/FirstPersonCharacter");
        TimeGlobal = GameObject.Find("LevelGlobals");
        rb = GetComponent<Rigidbody>();
        PlayerSpawn = GameObject.Find("PlayerSpawnPoint");
        MySphere = gameObject.GetComponentInChildren<SphereCollider>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        rb.AddRelativeForce(Vector3.forward * thrust);
        if (TimeGlobal.GetComponent<LevelGlobals>().TimeStopped == true)
        {
            //if time is stopped, move towards player?
        }
        /*
        if (TimeGlobal.GetComponent<LevelGlobals>().TimeStopped == true)
        {
            if (greyscalecounter < 0.1)
                greyscalecounter += Time.deltaTime;

            if (greyscalecounter >= 0.1)
            {
                WhereIsThePlayerOhMyGod.GetComponent<Grayscale>().enabled = false;
                //  WhereIsThePlayerOhMyGod.GetComponent<Grayscale>().textureRamp = NormalGreyscale;
            }
        }
        if (TimeGlobal.GetComponent<LevelGlobals>().TimeStopped == false)
        {
            greyscalecounter = 0f;
            WhereIsThePlayerOhMyGod.GetComponent<Grayscale>().enabled = false;
            //WhereIsThePlayerOhMyGod.GetComponent<TiltShift>().enabled = false;
        }

        if(Input.GetKeyDown("e"))
        {
            print("onagi type no sutando!?");
            //TimeGlobal.GetComponent<LevelGlobals>().TimeStopped = true;
            TimeGlobal.GetComponent<LevelGlobals>().OnagiTimeStopped = true;
            WhereIsThePlayerOhMyGod.GetComponent<Grayscale>().enabled = true;
            WhereIsThePlayerOhMyGod.GetComponent<Grayscale>().textureRamp = ColorGreyscale;
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}
