using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

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
            
           // Debug.Log("SetDir: " + GameObject.Find("Role(Clone)"));
            netPlayer.setDirection(Input.GetAxis("Horizontal"));
            //netPlayer.setSpeed(Input.GetAxis("Vertical"));
        }
	}

	public bool isLedTurnedOn(){
		return isOn;
	}
}
