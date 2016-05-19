using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Signs : MonoBehaviour {

	public UI signUI = new UI ();

	bool showSign = false;

	void Update (){
		
		if (showSign && Input.GetKeyDown(KeyCode.DownArrow)){
			signUI.WhatSignToShow (0);
		}
		if (Input.GetKeyDown(KeyCode.Return)){
			signUI.WhatSignToShow (1);
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player"){
			UI.CanInteract (0);
			showSign = true;
		}
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "Player"){
			UI.CanInteract (1);
			showSign = false;
		}
	}
}
