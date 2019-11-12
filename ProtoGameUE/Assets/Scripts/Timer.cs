using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    
        public Text Timing;
        public float startTime = 0.0f;
    
       

    void Update()
    {
        startTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(startTime / 60F);
        int seconds = Mathf.FloorToInt(startTime - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        Timing.text = niceTime;

    }

    void OnGUI()
    {
        
        

    }

}

