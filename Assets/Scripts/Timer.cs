using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float time_left = 3600f;
    public Text current_time; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time_left -= Time.deltaTime;
        displayTime();
	}

    public void displayTime()
    {

        int minutes = Mathf.FloorToInt(time_left / 60);
        int seconds = Mathf.FloorToInt(time_left % 60);
        int hundredths = Mathf.FloorToInt((time_left * 100) % 100);

        if (current_time)
            current_time.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, hundredths);
    }


}
