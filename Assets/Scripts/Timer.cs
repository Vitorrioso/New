using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public Text timeLevel_txt;
    private float timeLevel;
    public static bool stopTime;
//    private float totalTime;


    void Start()
    {
        stopTime = false;
//        totalTime = 30;

    }



    void Update()
    {

        if(stopTime==false)
        {
            timeLevel = timeLevel + Time.deltaTime;
            timeLevel_txt.text = timeLevel.ToString("F0");

        }
        
    }
}
