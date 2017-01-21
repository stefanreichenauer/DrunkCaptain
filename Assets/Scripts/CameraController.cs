using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public float velocityOffset = 0.5f;
	public float directionOffset = 1;
	private Vector3 offset;
	private Vector3 targetPosition;

	public float lagFactor = 0.4f;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(player != null){
			Rigidbody2D playerRigid = player.GetComponent<Rigidbody2D>();
			Vector3 dynamicOffset = player.transform.up.normalized * (directionOffset + playerRigid.velocity.magnitude * velocityOffset);
			targetPosition = player.transform.position + offset + dynamicOffset;
			this.transform.position += (targetPosition - this.transform.position) * lagFactor;
		}
	}
}
