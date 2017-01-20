using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControls : MonoBehaviour {

	public SteeringWheel steeringWheel;
	public Throttle throttle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float deltax = Input.GetAxis("Horizontal");
		float deltay = Input.GetAxis("Vertical");

		steeringWheel.rotateFor(deltax);
		throttle.addValue(deltay);
	}
}
