using UnityEngine;
using System.Collections;

public class ProjectileTimeStopLogic : MonoBehaviour 
{
    private GameObject TimeGlobal;

    private Rigidbody MyBody;

    private Vector3 OldVelocity;

    public float lifetime = 2.0f;

    private float counter;

    public bool AmIOnCube = false;

    private float lerpToStopCounter = 0f;
    private float slowdownSpeed = 0.3f;

    private bool stoptimeLerpdone = false;
    private bool normaltimeLerpdone = false;

    private bool timeNotStoppedYet = false;

    public bool Large = false;
    public bool Small = false;
    public GameObject LargeAfterImage;
    public GameObject SmallAfterImage;

    private DamageFlashController DamageFlashOnCanvas;

    private float delay = 0f;
    //private DamageFlashController DamageFlashOnCanvas;

    public GameObject PreFabToMake;
    // Use this for initialization
    void Start () 
	{
        TimeGlobal = GameObject.Find("LevelGlobals");
        MyBody = GetComponent<Rigidbody>();
        OldVelocity = MyBody.velocity;
        //DamageFlashOnCanvas = GameObject.Find("Canvas/DamageFlash").GetComponent<DamageFlashController>() ;
        if(AmIOnCube == true)
        {
            Large = true;
        }
        if(AmIOnCube == false)
        {
            Small = true;
        }
        DamageFlashOnCanvas = GameObject.Find("Canvas/DamageFlash").GetComponent<DamageFlashController>();
    }
	
	// Update is called once per frame
	void Update () 
	{
        /*delay += Time.deltaTime;
        if(TimeGlobal.GetComponent<LevelGlobals>().TimeStopped == true && delay > 0.5f)
        {
            if(Large == true)
            {
               // Instantiate(LargeAfterImage, gameObject.transform.position, Quaternion.identity);
                delay = 0f;
            }

            if(Small == true)
            {
              //  Instantiate(SmallAfterImage, gameObject.transform.position, Quaternion.identity);
                delay = 0f;
            }
        }*/

        //time is stopped
        if (TimeGlobal.GetComponent<LevelGlobals>().TimeStopped == true && AmIOnCube == false)
        {
            gameObject.transform.Find("warp1").GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.Find("warp2").GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.Find("warp3").GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.Find("warp4").GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.Find("warp5").GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.Find("warp6").GetComponent<MeshRenderer>().enabled = true;

            timeNotStoppedYet = true;
            normaltimeLerpdone = false;
            if(lerpToStopCounter >= slowdownSpeed)
            {
                stoptimeLerpdone = true;
                MyBody.velocity = Vector3.zero;//OldVelocity / TimeGlobal.GetComponent<LevelGlobals>().TimeSlowScale;
                lerpToStopCounter = 0f;
                return;
            }

            if(stoptimeLerpdone == false)
            {
                //counter that is incremented with time / how long it takes to get to zero
                MyBody.velocity = Vector3.zero;// Vector3.Lerp(OldVelocity, Vector3.zero, slowdownSpeed);
               lerpToStopCounter += Time.deltaTime;
            }

            //print(MyBody.velocity);
           
           // return;
        }

        //time resumes....
        if (TimeGlobal.GetComponent<LevelGlobals>().TimeStopped == false && AmIOnCube == false)
        {
            gameObject.transform.Find("warp1").GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.Find("warp2").GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.Find("warp3").GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.Find("warp4").GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.Find("warp5").GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.Find("warp6").GetComponent<MeshRenderer>().enabled = false;

            if (timeNotStoppedYet == false)
            {
                MyBody.velocity = OldVelocity;
            }

            if(timeNotStoppedYet == true)
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

            counter += Time.deltaTime;

            if (counter >= lifetime && AmIOnCube == false)
            {
                GameObject StandPower = (GameObject)Instantiate(PreFabToMake, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "StandIgnore")
        {
            print("touched the player");
            DamageFlashOnCanvas.EnableScreen();
            GameObject StandPower = (GameObject)Instantiate(PreFabToMake, transform.position, transform.rotation);

            if (AmIOnCube == false)
            {
                Destroy(gameObject);
                //TimeGlobal.GetComponent<LevelGlobals>().DestroyedOrbsCount++;
            }

        }

        //print(col.gameObject.tag);
        if (col.gameObject.tag == "DoYouUnderstand")
        {
            //print("touched a knife");
            GameObject StandPower = (GameObject)Instantiate(PreFabToMake, transform.position, transform.rotation);

            if (AmIOnCube == false)
            {
                Destroy(gameObject);
                //TimeGlobal.GetComponent<LevelGlobals>().DestroyedOrbsCount++;
            }
        }





    }
}
