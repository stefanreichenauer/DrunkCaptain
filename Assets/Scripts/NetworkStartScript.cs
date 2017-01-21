using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkStartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //start network game
    public void startGameAsServer()
    {
        //load new scene
        //store ip in game state?!
        GetComponent<NetworkManager>().StartServer();
    }

    public void startGameAsClient(string ip)
    {
        //GetComponent<NetworkManager>().networkAddress;
        //GetComponent<NetworkManager>().networkPort;
        GetComponent<NetworkManager>().StartClient();
    }
}
