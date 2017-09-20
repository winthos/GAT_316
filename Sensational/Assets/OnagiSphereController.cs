using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnagiSphereController : MonoBehaviour 
{
    public Transform PlayerSpawn;
    private DamageFlashController DamageFlashOnCanvas;

    // Use this for initialization
    void Start () 
    {
        PlayerSpawn = GameObject.Find("PlayerSpawnPoint").GetComponent<Transform>();
        DamageFlashOnCanvas = GameObject.Find("Canvas/DamageFlash").GetComponent<DamageFlashController>();
    }
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="StandIgnore")
        {
            print("touched the player w/ sphere");
            other.gameObject.GetComponent<Transform>().position = PlayerSpawn.position;
            DamageFlashOnCanvas.EnableScreen();
        }
    }
}
