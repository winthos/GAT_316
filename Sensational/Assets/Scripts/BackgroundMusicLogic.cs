using UnityEngine;
using System.Collections;

public class BackgroundMusicLogic : MonoBehaviour 
{
    private bool IsTimeStopped;
    public float NewPitch = 1.37f;
    public float NewVolume = 0.4f;
	// Use this for initialization
	void Start () 
	{
        IsTimeStopped = GameObject.Find("LevelGlobals").GetComponent<LevelGlobals>().TimeStopped;
	}
	
	// Update is called once per frame
	void Update () 
	{
        IsTimeStopped = GameObject.Find("LevelGlobals").GetComponent<LevelGlobals>().TimeStopped;
        if (IsTimeStopped == true)
        {
            //turn on filter
            AudioReverbFilter filter = GetComponent<AudioReverbFilter>();
            filter.enabled = true;
            AudioReverbZone zone = GetComponent<AudioReverbZone>();
            zone.enabled = true;

            AudioSource source = GetComponent<AudioSource>();
            source.volume = NewVolume;
            source.pitch = NewPitch;

        }

        if (IsTimeStopped == false)
        {
            //turn off filter
            AudioReverbFilter filter = GetComponent<AudioReverbFilter>();
            filter.enabled = false;
            AudioReverbZone zone = GetComponent<AudioReverbZone>();
            zone.enabled = false;

            AudioSource source = GetComponent<AudioSource>();
            source.volume = 1.0f;
            source.pitch = 1.0f;
        }

	}
}
