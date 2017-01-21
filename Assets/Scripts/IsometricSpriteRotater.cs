using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricSpriteRotater : MonoBehaviour {

	public GameObject follow;
	public Sprite[] sprites;

	public SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
		//spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = follow.transform.position;
		float subSection = 360/sprites.Length;
		float angle = -follow.transform.rotation.eulerAngles.z + subSection/2;
		while(angle > 360){
			angle -= 360;
		}
		while(angle < 0){
			angle += 360;
		}
		int index = (int)(angle/subSection);
		spriteRenderer.sprite = sprites[index];
	}
}
