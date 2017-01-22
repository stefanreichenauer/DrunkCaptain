using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkStarter : MonoBehaviour
{

    private bool choosen = false;
    private bool client = false;
   

    public GameObject menuManagerObj;
    public MenuManager menuManager;

    // Use this for initialization
    void Start()
    {
        menuManagerObj = GameObject.Find("MenuManager");
        menuManager = menuManagerObj.GetComponent<MenuManager>();
        Debug.Log(menuManagerObj);
        if (menuManager.isCaptain)
        {
            GetComponent<NetworkManager>().networkPort = menuManager.connectionPort;
            Debug.Log("Server Create");
            choosen = true;
            GetComponent<NetworkManager>().StartServer();
        }
        else
        {
            GetComponent<NetworkManager>().networkAddress = menuManager.ip;
            GetComponent<NetworkManager>().networkPort = menuManager.connectionPort;
            GetComponent<NetworkManager>().StartClient();
            Debug.Log("Client connect");
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    
}
