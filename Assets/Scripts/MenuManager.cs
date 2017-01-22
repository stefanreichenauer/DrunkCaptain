using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public bool isCaptain = true;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

	public void startGame(){
		testP1();
	}

	public void testP1(){
		SceneManager.LoadScene("NetworkView");
	}
	public void testP2(){
        isCaptain = false;
		SceneManager.LoadScene("NetworkView");
        
    }

	public void quitGame(){
		Application.Quit();
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}
}
