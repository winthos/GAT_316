using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeParticleTimeLogic : MonoBehaviour {

    private GameObject TimeGlobal;

    private float PlayParticleForASecond = 0.2f;
    // Use this for initialization
    void Start () 
    {
        TimeGlobal = GameObject.Find("LevelGlobals");
    }
	
	// Update is called once per frame
	void Update () 
    {
        if(GetComponent<ParticleSystem>().IsAlive() == false)
        {
            Destroy(gameObject);
        }

		if(TimeGlobal.GetComponent<LevelGlobals>().TimeStopped == true)
        {
            PlayParticleForASecond -= Time.deltaTime;
            if(PlayParticleForASecond <= 0f && GetComponent<ParticleSystem>().isPlaying == true)
            {
                print("pause the particle");
                GetComponent<ParticleSystem>().Pause();
            }
        }

        if(TimeGlobal.GetComponent<LevelGlobals>().TimeStopped == false)
        {
            PlayParticleForASecond = 0.2f;
            if(GetComponent<ParticleSystem>().isPlaying == false)
            {
                GetComponent<ParticleSystem>().Play();
            }
        }
	}
}
