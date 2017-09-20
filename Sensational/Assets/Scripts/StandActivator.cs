using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StandActivator : MonoBehaviour
{
    private GameObject TimeGlobal;
    //spawn the stand
    public GameObject PreFabToMake;
    public float Cooldown = 2f;
    public float TimeStopCooldown = 0.2f;
    private float CoolDownTimer;

    public bool ReadyToActivate = true;

    public GameObject CooldownCursor;

    public GameObject KnifeCooldownBar;

    public GameObject KnifeSpawnPoint = null;

    public float speed = 10f;

    public int NumberOfKnivesLeft = 10;

    private bool dothisonce = false;

    public float HowMuchLongerTillIHaveMoreKnives = 2.0f;
    public float KniveReloadCounter = 0.0f;

    public GameObject[] KnifeUIStuff;

    public GameObject[] KnifeModels;

    public AudioClip ReloadClip;

    public GameObject KnivesInHand;

    // Use this for initialization
    void Start()
    {
        CoolDownTimer = Cooldown;
        TimeGlobal = GameObject.Find("LevelGlobals");
    }

    // Update is called once per frame
    void Update()
    {
        for(int index = 0; index < 10 - NumberOfKnivesLeft; index++)
        {
            KnifeUIStuff[index].GetComponent<Image>().enabled = false;
            KnifeModels[index].SetActive(false);
        }
        
        if (TimeGlobal.GetComponent<LevelGlobals>().TimeStopped == true)
        {
            dothisonce = false;
            CoolDownTimer = -1;
        }

        //do this once every time you go back to normal time
        if (TimeGlobal.GetComponent<LevelGlobals>().TimeStopped == false)
        {
            if (dothisonce == false)
            {
                CoolDownTimer = Cooldown;
                dothisonce = true;
            }

            //if we are in normal time and we are out of knives, begin knife reload timer

            if(NumberOfKnivesLeft <= 0)
            {
                KniveReloadCounter += Time.deltaTime;
                
                KnifeCooldownBar.GetComponent<Image>().fillAmount =  KniveReloadCounter / HowMuchLongerTillIHaveMoreKnives;
                if (KniveReloadCounter >= HowMuchLongerTillIHaveMoreKnives)
                {
                    //here we reload our knives n stuff
                    NumberOfKnivesLeft = 10;
                    KniveReloadCounter = 0f; //reset the counter oops
                    KnifeCooldownBar.GetComponent<Image>().fillAmount = 0;
                    KnivesInHand.GetComponent<KnivesInHandController>().Reset();
                    GetComponent<AudioSource>().PlayOneShot(ReloadClip);
                    for (int index = 0; index < NumberOfKnivesLeft; index++)
                    {
                        KnifeUIStuff[index].GetComponent<Image>().enabled = true;
                        KnifeModels[index].SetActive(true);
                    }
                }
            }

        }


        if (ReadyToActivate == false)
        {
            CoolDownTimer -= Time.deltaTime;
            CooldownCursor.GetComponent<Image>().fillAmount = CoolDownTimer / Cooldown;
            //print(CoolDownTimer);
            if (CoolDownTimer <= 0)
            {
                CoolDownTimer = Cooldown;
                ReadyToActivate = true;
            }
        }

        if (Input.GetMouseButtonDown(0) && ReadyToActivate == true)
        {
            if(NumberOfKnivesLeft > 0)
            {
                ReadyToActivate = false;
                Vector3 SpawnPos = KnifeSpawnPoint.GetComponent<Transform>().position;
                //SpawnPos.z += 1.5f;
                SpawnPos.x += Random.Range(-0.5f, 0.5f);
                SpawnPos.y += Random.Range(-0.5f, 0.5f);

                GameObject StandPower = (GameObject)Instantiate(PreFabToMake, SpawnPos, transform.rotation);
                StandPower.GetComponent<Rigidbody>().velocity = transform.forward * speed;

                NumberOfKnivesLeft -= 1;
            }


        }
        

    }
}
