using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeStopInUseImageLogic : MonoBehaviour 
{
    private GameObject TimeGlobal;
    // Use this for initialization
    public Image image;

    private float scale;
    void Start () 
    {
        TimeGlobal = GameObject.Find("LevelGlobals");
        image = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (TimeGlobal.GetComponent<LevelGlobals>().TimeStopped == true)
        {
            //gameObject.GetComponent<Color>
 
            var tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;

            gameObject.GetComponent<RectTransform>().localScale = new Vector3 (Mathf.PingPong(Time.time * 2, 1) + 1, gameObject.GetComponent<RectTransform>().localScale.x, gameObject.GetComponent<RectTransform>().localScale.y);
            //transform.localScale = new Vector3(scale, scale, scale);
            //transform.localScale.Set(scale,scale,scale);
        }

        if(TimeGlobal.GetComponent<LevelGlobals>().TimeStopped == false)
        {
            var tempColor = image.color;
            tempColor.a = 0f;
            image.color = tempColor;
        }

    }
}
