using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

	public string button;

	private bool isOn;

    void Start()
    {
    }
	
	// Update is called once per frame
	void Update () {
	}

	public bool isLedTurnedOn(){
		return isOn;
	}
}
