using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDStateProvider : MonoBehaviour {

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
        if (!netPlayer.isServerEntity)
        {
            switch (button)
            {
                case "up":
                    isOn = gameState.er_up;
                    break;
                case "down":
                    isOn = gameState.er_down;
                    break;
                case "left":
                    isOn = gameState.er_left;
                    break;
                case "right":
                    isOn = gameState.er_right;
                    break;
                default:
                    break;
            }
        }
	}

	public bool isLedTurnedOn(){
		return isOn;
	}
}
