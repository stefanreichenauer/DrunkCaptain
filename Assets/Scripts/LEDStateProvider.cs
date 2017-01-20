using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDStateProvider : MonoBehaviour {

	public string button;

	private bool isOn;
	
	// Update is called once per frame
	void Update () {
		isOn = Input.GetButton(button);
	}

	public bool isLedTurnedOn(){
		return isOn;
	}
}
