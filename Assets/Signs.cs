using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Signs : MonoBehaviour {

	// Making an instance of the UI, to use its functions
	public UI signUI = new UI ();

	bool showSign = false;

	void Update (){

		// If no sign-text is active and the player presses down, it shows a sign-text according to the scene index
		if (showSign && Input.GetKeyDown(KeyCode.DownArrow)){
			signUI.WhatSignToShow (SceneManager.GetActiveScene().buildIndex-1);
		}
		// Hide sign-text
		if (Input.GetKeyDown(KeyCode.Return)){
			signUI.WhatSignToShow (2);
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		// Lights up the interaction-button when the player is near the sign
		if (other.gameObject.tag == "Player"){
			UI.CanInteract (0);
			showSign = true;
		}
	}

	// Fades out the sign-text if the player walks away from the sign 
	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "Player"){
			UI.CanInteract (1);
			showSign = false;
		}
	}
}
