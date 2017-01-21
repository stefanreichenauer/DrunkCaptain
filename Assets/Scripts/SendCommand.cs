using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendCommand : MonoBehaviour {

	public string button;

	private bool isOn;

    public GameObject role;
    public GameObject gameStateObject;

    private GameState gameState;

    private NetworkPlayer netPlayer;

    void Start()
    {
        gameState = gameStateObject.GetComponent<GameState>();
        netPlayer = role.GetComponent<NetworkPlayer>();
    }
	
	// Update is called once per frame
	void Update () {

	}

	public bool isLedTurnedOn(){
		return isOn;
	}
}
