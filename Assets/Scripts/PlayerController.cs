using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    float shipAcceleration;
    float shipSteeringDirection;
    public GameObject player;
    public Rigidbody2D rigid;
    public Text winText;
    public Transform goal;
    public Transform compass;

    public float shipMaxSpeed;
    public float shipAccelerationForce;
    public float shipSteeringAmount;


    // Use this for initialization
    void Start () {
        shipAcceleration = 0f;
        shipSteeringDirection = 0f;
        //cam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y,-10);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (!Input.GetAxis("Horizontal").Equals(0))
        {
            shipSteeringDirection = -Input.GetAxis("Horizontal") * shipSteeringAmount;

            if (Input.GetAxis("Horizontal") < 0 && shipSteeringDirection >= 1f)
            {
                shipSteeringDirection = 1f;
            }

            if (Input.GetAxis("Horizontal") > 0 && shipSteeringDirection <= -1f)
            {
                shipSteeringDirection = -1f;
            }
        }
        else
        {
            if(shipSteeringDirection > 0)
            {
                shipSteeringDirection -= 0.01f;
            }
            else if(shipSteeringDirection < 0)
            {
                shipSteeringDirection += 0.01f;
            }
        }
        shipAcceleration = Input.GetAxis("Vertical") * shipAccelerationForce;

        //Debug.Log("Vel: " + rigid.angularDrag + " - " + shipDirection);
        
        float newRotation = player.transform.rotation.eulerAngles.z + shipSteeringDirection;
        player.transform.rotation = Quaternion.Euler(0, 0, newRotation);
       
        if (rigid.velocity.magnitude > shipMaxSpeed)
        {
            rigid.AddForce(rigid.velocity * (-0.1f));
        }
        rigid.AddForce(player.transform.up * shipAcceleration);

        Debug.Log("Vel: " + newRotation + " - " + rigid.velocity.magnitude + " - " + Vector3.Dot(rigid.velocity.normalized, player.transform.up));

        //cam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);

        float compassDirection = Vector3.Angle(Vector3.up,player.transform.position - goal.transform.position);
        //Debug.Log("Vel: " + compassDirection);
        compass.transform.rotation = Quaternion.Euler(0,0, compassDirection+180);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!coll.Equals(null))
        {
            shipAcceleration = 0;
            rigid.velocity = new Vector3(0, 0, 0);
        }
    } 
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Finish"){
            winText.gameObject.SetActive(true);
        }else if(other.tag == "Wave"){
            other.GetComponent<Wave>().register(this.rigid);
        }
    }

    /// <summary>
    /// Sent when another object leaves a trigger collider attached to
    /// this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Wave"){
            other.GetComponent<Wave>().unregister(this.rigid);
        }
    }

}
