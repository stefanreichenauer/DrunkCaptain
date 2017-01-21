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
        if (netPlayer.isServerEntity)
        {

            gameState.er_up = Input.GetAxis("Vertical") > 0;
            gameState.er_down = Input.GetAxis("Vertical") < 0;
            gameState.er_right = Input.GetAxis("Horizontal") > 0;
            gameState.er_left = Input.GetAxis("Horizontal") < 0;

            if (Input.GetAxis("Vertical") != 0.0f || Input.GetAxis("Horizontal") != 0.0f)
                Debug.Log("GG");
        }
	}

	public bool isLedTurnedOn(){
		return isOn;
	}
}
