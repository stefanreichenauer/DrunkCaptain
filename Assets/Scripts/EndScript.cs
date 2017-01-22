using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour {

    public GameObject menuManagerObj;
    public MenuManager menuManager;

    public Text endText;
	public Sprite final_image_win;
	public Sprite final_image_fail;
	public GameObject image_background;
    float waitTime = -1;
    // Use this for initialization
    void Start()
    {
        menuManagerObj = GameObject.Find("MenuManager");
        menuManager = menuManagerObj.GetComponent<MenuManager>();
        if (menuManager.isSuccess)
        {
            //endText.text = "You won";
			image_background.GetComponent<Image> ().sprite = final_image_win;

        }
        else
        {
            //endText.text = "Loooooooooooooooooooooooooser";
			image_background.GetComponent<Image> ().sprite = final_image_fail;
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
