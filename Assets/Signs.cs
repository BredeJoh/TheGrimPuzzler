using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Signs : MonoBehaviour {

	public UI signUI = new UI ();

	bool showSign = false;

	void Update (){
		
		if (showSign && Input.GetKeyDown(KeyCode.DownArrow)){
			signUI.WhatSignToShow (SceneManager.GetActiveScene().buildIndex-1);
		}
		if (Input.GetKeyDown(KeyCode.Return)){
			signUI.WhatSignToShow (2);
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
