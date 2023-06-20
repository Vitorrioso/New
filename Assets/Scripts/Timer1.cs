using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Timer1 : MonoBehaviour
{
    public Text timeLevel_txt;
    private float timeLevel;
    public static bool stopTime;
    public float timer;
    
//    private float totalTime;


    void Start()
    {
        stopTime = false;
//        totalTime = 30;

    }



    private void Update()
    {



    if (stopTime == false)
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            timeLevel_txt.text = timer.ToString("F0");
        }
        else
        {
//            stopTime = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
        }
    }




    }
}
