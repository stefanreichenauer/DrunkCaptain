using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkGUI : NetworkBehaviour
{

    private bool choosen = false;
    private bool client = false;

    public string connectionIP = "127.0.0.1";
    public int connectionPort = 7777;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public string txt = "Enter your Captains IP!";

    void OnGUI()
    {
        if (client)
        {
            txt = GUI.TextField(new Rect(10, 30, 300, 20), txt, 30);
            if (GUI.Button(new Rect(320, 30, 40, 20), "GO!"))
            {
                GetComponent<NetworkManager>().networkAddress = txt;
                GetComponent<NetworkManager>().networkPort = connectionPort;
                client = false;
                GetComponent<NetworkManager>().StartClient();
                Debug.Log("Client connect");
            }
        }

        if (!choosen)
        {
            if (GUI.Button(new Rect(10, 30, 120, 20), "Client Connect"))
            {
                choosen = true;
                client = true;
            }
            if (GUI.Button(new Rect(10, 60, 120, 20), "Server Create"))
            {
                GetComponent<NetworkManager>().networkPort = connectionPort;
                Debug.Log("Server Create");
                choosen = true;
                GetComponent<NetworkManager>().StartServer();
            }
        }
    }
}
