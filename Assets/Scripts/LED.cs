using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LED : MonoBehaviour {

	public Sprite onSprite;
	public Sprite offSprite;

	public Image imagePlaceholder;

	public LEDStateProvider stateProvider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		setEnabled(stateProvider.isLedTurnedOn());
	}

	public void setEnabled(bool enabled){
		if(enabled){
			imagePlaceholder.sprite = onSprite;
		}else{
			imagePlaceholder.sprite = offSprite;
		}
	}
}
