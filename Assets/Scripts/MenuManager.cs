using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class MenuManager : MonoBehaviour {

    public bool isCaptain = true;

    private bool choosen = false;
    private bool client = false;

    public string connectionIP = "127.0.0.1";
    public int connectionPort = 7777;
    
    public string ip = "127.0.0.1";

    public GameObject buttons;


    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

	public void startGame(){
		testP1();
	}

	public void testP1(){
        //Captain/Server
        buttons.SetActive(false);
        SceneManager.LoadScene("NetworkView");

    }
	public void testP2()
    {
        //Helmsman/Client
        isCaptain = false;
        buttons.SetActive(false);
        SceneManager.LoadScene("NetworkView");
        
    }

	public void quitGame(){
		Application.Quit();
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}
}
