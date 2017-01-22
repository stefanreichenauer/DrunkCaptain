using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public bool isCaptain = true;

    private bool choosen = false;
    private bool client = false;

    public string connectionIP = "127.0.0.1";
    public int connectionPort = 7777;

    public string ip = "127.0.0.1";

    public GameObject buttons;
    public GameObject IPbuttons;

    public Text ipInput;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void startGame()
    {
        testP1();
    }

    public void testP1()
    {
        //Captain/Server
        isCaptain = true;
        buttons.SetActive(false);
        SceneManager.LoadScene("NetworkView");

    }
    public void testP2()
    {
        buttons.SetActive(false);
        IPbuttons.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void backBtn()
    {
        buttons.SetActive(true);
        IPbuttons.SetActive(false);

    }

    public void submitBtn()
    {
        //Helmsman/Client
        isCaptain = false;
        ip = ipInput.text;
        buttons.SetActive(false);
        SceneManager.LoadScene("NetworkView");

    }
}
