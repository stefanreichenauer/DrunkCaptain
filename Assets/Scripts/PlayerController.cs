using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float shipVelocity;
    float shipDirection;
    public GameObject player;
    public Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
        shipVelocity = 0f;
        shipDirection = player.transform.rotation.z;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (!Input.GetAxis("Horizontal").Equals(0))
        {
            shipDirection -= Input.GetAxis("Horizontal");
        }
        if (!Input.GetAxis("Vertical").Equals(0))
        {
            shipVelocity += Input.GetAxis("Vertical") * 0.05f;
        }
      /*
        Vector3 newPosition = player.transform.position + player.transform.up * shipVelocity;
        float newRotation = player.transform.rotation.z + shipDirection;

        Debug.Log("Pos: " + newPosition);
        Debug.Log("Rot: " + newRotation);
        player.transform.position = newPosition;
        player.transform.rotation = Quaternion.Euler(0, 0, newRotation);
        */

        float newRotation = player.transform.rotation.z + shipDirection;
        player.transform.rotation = Quaternion.Euler(0, 0, newRotation);
        rigid.AddForce(player.transform.up * shipVelocity);

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!coll.Equals(null))
        {
            shipVelocity = 0;
        }
    }
}
