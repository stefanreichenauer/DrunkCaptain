using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class Throttle:MonoBehaviour {

	public float returnToNullForce = 0; 
	public float maxValue = 100; 
	public float minValue = -100; 
	public float changeForce = 5; 
	public float currentValue = 0; 
	
	private Vector2 initialPosition; 
	// Use this for initialization
	void Start () {
		initialPosition = transform.position; 
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (currentValue > maxValue) {
			currentValue = maxValue; 
		}else if (currentValue <  -maxValue) {
			currentValue =  -maxValue; 
		}
		transform.position = initialPosition +new Vector2(0, currentValue); 
		if (currentValue > returnToNullForce) {
			currentValue -= returnToNullForce; 
		}else if (currentValue < -returnToNullForce) {
			currentValue += returnToNullForce; 
		}else {
			currentValue = 0; 
		}
	}

	public void addValue(float delta) {
		currentValue += delta * changeForce; 
	}
}
