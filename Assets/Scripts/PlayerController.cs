﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    float shipVelocity;
    float shipDirection;
    public GameObject player;
    public Rigidbody2D rigid;
    public Text winText;
    public Transform goal;
    public Transform compass;
    // public Camera cam;


    // Use this for initialization
    void Start () {
        shipVelocity = 0f;
        shipDirection = 0f;
        //cam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y,-10);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (!Input.GetAxis("Horizontal").Equals(0))
        {
            shipDirection -= Input.GetAxis("Horizontal") * 0.01f;

            if (Input.GetAxis("Horizontal") < 0 && shipDirection >= 1f)
            {
                shipDirection = 1f;
            }

            if (Input.GetAxis("Horizontal") > 0 && shipDirection <= -1f)
            {
                shipDirection = -1f;
            }
        }
        else
        {
            if(shipDirection > 0)
            {
                shipDirection -= 0.01f;
            }
            else if(shipDirection < 0)
            {
                shipDirection += 0.01f;
            }
        }
        if (!Input.GetAxis("Vertical").Equals(0))
        {
            shipVelocity = Input.GetAxis("Vertical");

            if(Input.GetAxis("Vertical") > 0 && shipVelocity >= .5f)
            {
                shipVelocity = .5f;
            }

            if (Input.GetAxis("Vertical") < 0 && shipVelocity <= -.5f)
            {
                shipVelocity = -.5f;
            }
        }
        else
        {
            shipVelocity = 0f;
        }

        //Debug.Log("Vel: " + rigid.angularDrag + " - " + shipDirection);
        
        float newRotation = player.transform.rotation.eulerAngles.z + shipDirection;
        player.transform.rotation = Quaternion.Euler(0, 0, newRotation);
        
        if (shipVelocity == 0f && rigid.velocity.magnitude > 0)
        {
            rigid.AddForce(rigid.velocity * (-0.1f));
        }
        else {
            rigid.AddForce(player.transform.up * shipVelocity);
        }

        //Debug.Log("Vel: " + rigid.velocity.normalized + " - " + player.transform.up + " - " + Vector3.Dot(rigid.velocity.normalized, player.transform.up));

        //cam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);

        float compassDirection = Vector3.Angle(Vector3.up,player.transform.position - goal.transform.position);
        Debug.Log("Vel: " + compassDirection);
        compass.transform.rotation = Quaternion.Euler(0,0, compassDirection+180);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!coll.Equals(null))
        {
            shipVelocity = 0;
            rigid.velocity = new Vector3(0, 0, 0);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        winText.gameObject.SetActive(true);
    }

}
