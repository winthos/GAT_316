using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeParticleSoundController : MonoBehaviour 
{
    private AudioSource audiosource;
    public AudioClip[] Whooshes;
    private AudioClip WhooshPlay;

    // Use this for initialization
    void Start () 
    {
        audiosource = gameObject.GetComponent<AudioSource>();
        int index = Random.Range(0, Whooshes.Length);
        WhooshPlay = Whooshes[index];
        audiosource.clip = WhooshPlay;
        audiosource.Play();

    }

    // Update is called once per frame
    void Update () 
    {
		
	}
}
