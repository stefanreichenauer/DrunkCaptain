using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void startGame(){
		testP1();
	}

	public void testP1(){
		SceneManager.LoadScene("CaptainsView");
	}
	public void testP2(){
		SceneManager.LoadScene("SteuermannView");
	}

	public void quitGame(){
		Application.Quit();
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}
}
