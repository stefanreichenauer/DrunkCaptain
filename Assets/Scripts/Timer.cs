using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public float time_left = 10f;
    public Text current_time;
    public Text winText;

    public bool running = false;
    public GameObject gameStateObj;
    private GameState gameState;
    public GameObject helmsmansText;
    // Use this for initialization
    void Start () {
        gameState = gameStateObj.GetComponent<GameState>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (running)
        {

            if (gameState.gameState == State.StateEnum.SUCCESS || gameState.gameState == State.StateEnum.FAILURE)
            {
                running = false;
            }
            time_left -= Time.deltaTime;

            if (time_left <= 0f)
            {
                current_time.gameObject.SetActive(false);
                gameState.timeOver();
                //   StartCoroutine("GameOver");
            }

            displayTime();
        }
        else
        {
            if(gameState.gameState == State.StateEnum.RUNNING)
            {
                running = true;
                current_time.gameObject.SetActive(true);
                helmsmansText.SetActive(false);
            }
        }
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
        gameState.timeOver();
        winText.text = "Game Over";
        winText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }

}
