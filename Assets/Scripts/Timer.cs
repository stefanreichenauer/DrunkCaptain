using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public float time_left = 10f;
    public Text current_time;
    public Text winText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time_left -= Time.deltaTime;

        if(time_left <= 0f)
        {
            current_time.gameObject.SetActive(false);
            StartCoroutine("GameOver");
        }

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

    IEnumerator GameOver()
    {
        winText.text = "Game Over";
        winText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }

}
