using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

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
        if (!netPlayer.isServerEntity)
        {
            netPlayer.setDirection(Input.GetAxis("Horizontal"));
            netPlayer.setSpeed(Input.GetAxis("Vertical"));
        }
	}

	public bool isLedTurnedOn(){
		return isOn;
	}
}
