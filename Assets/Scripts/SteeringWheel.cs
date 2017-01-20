using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class SteeringWheel:MonoBehaviour {

	public float returnToNullForce = 1f; 
	public float rotateSpeed = 5f; 
	public float maxRotation = 170; 
	public float currentRotation = 0; 

	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (currentRotation > maxRotation) {
			currentRotation = maxRotation; 
		}else if (currentRotation < -maxRotation) {
			currentRotation =  -maxRotation; 
		}
		Quaternion originalRot= transform.rotation; 
		transform.rotation= Quaternion.AngleAxis(currentRotation, Vector3.back); 
		 if (currentRotation > returnToNullForce) {
			 currentRotation -= returnToNullForce; 
		 }else if (currentRotation < -returnToNullForce) {
			currentRotation += returnToNullForce; 
		 }else {
			 currentRotation= 0; 
		 }
	}

	public void rotateFor(float delta) {
		currentRotation += delta * rotateSpeed; 
	}
}
