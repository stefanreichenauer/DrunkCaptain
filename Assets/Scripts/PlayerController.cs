using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float shipVelocity;
    float shipDirection;
    public GameObject player;

	// Use this for initialization
	void Start () {
        shipVelocity = 0f;
        shipDirection = 0f;
    }
	
	// Update is called once per frame
	void Update () {

        if (!Input.GetAxis("Horizontal").Equals(0))
        {
            shipDirection += Input.GetAxis("Horizontal");
        }
        if (!Input.GetAxis("Vertical").Equals(0))
        {
            shipDirection += Input.GetAxis("Vertical");
        }

       // Vector3 newPosition = player.transform.position + 
    }
}
