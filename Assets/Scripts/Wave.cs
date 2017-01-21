using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

	public float power = 3;

	public float duration = 5;
	private float startTime;

	private Rigidbody2D pushed;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Time.time > startTime + duration){
			Destroy (this.gameObject);
		}
		if(pushed != null){
			push(pushed);
		}
	}

	public void push(Rigidbody2D other){
		other.AddForce(transform.right * -1, ForceMode2D.Force);
	}
	public void register(Rigidbody2D other){
		pushed = other;
	}
	public void unregister(Rigidbody2D other){
		pushed = null;
	}
}
