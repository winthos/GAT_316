using UnityEngine;
using System.Collections;

public class WaitThenDestroy : MonoBehaviour 
{
    public float timer = 2f;
    private GameObject TimeGlobal;

    // Use this for initialization
    void Start () 
	{
        TimeGlobal = GameObject.Find("LevelGlobals");
    }
	
	// Update is called once per frame
	void Update () 
	{
        if(TimeGlobal.GetComponent<LevelGlobals>().TimeStopped == false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Destroy(gameObject);
            }
        }

	}
}
