﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDStateProvider : MonoBehaviour {

	public string button;

	private bool isOn;

    public GameObject role;

    private GameState gameState;

    private NetworkPlayer netPlayer;

    void Start()
    {
        gameState = role.GetComponent<GameState>();
        netPlayer = role.GetComponent<NetworkPlayer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (netPlayer.isServerEntity)
        {
		    isOn = Input.GetButton(button);
        }
	}

	public bool isLedTurnedOn(){
		return isOn;
	}
}
