using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour {

    public GameObject menuManagerObj;
    public MenuManager menuManager;

    public Text endText;

    float waitTime = -1;
    // Use this for initialization
    void Start()
    {
        menuManagerObj = GameObject.Find("MenuManager");
        menuManager = menuManagerObj.GetComponent<MenuManager>();
        if (menuManager.isSuccess)
        {
            endText.text = "You won";
        }
        else
        {
            endText.text = "Loooooooooooooooooooooooooser";
        }
        waitTime = Time.time;

    }
	
	// Update is called once per frame
	void Update () {
        if(waitTime + 5 < Time.time)
        {

            menuManager.buttons.SetActive(true);
            SceneManager.LoadScene("MainMenu");
        }

		
	}
}
