﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BruteSpawner : MonoBehaviour {

	// Variables
	public Transform brutePrefab;
	public Transform bruteSpawner;
	public Transform currentBrute;

	public GameObject particle;
	
	float nextTimeToSearch = 0;
	// If limit is true a gameobject can be spawned
	public bool limit;
	
	// Use this for initialization
	void Start () {
		

		limit = true;
	}
	
	void FixedUpdate(){
	// Checks if there is a brute in the scene
		if (currentBrute == null) {
			limit = true;

			particle.SetActive (true);
			
			if (nextTimeToSearch <= Time.time) {
				GameObject searchResult = GameObject.FindGameObjectWithTag ("brute");	
				if (searchResult != null){
					currentBrute = searchResult.transform;
					limit = false;
					particle.SetActive (false);
					nextTimeToSearch = Time.time + 0.5f;
				}
			}
		}
	}

	// Stops the spawner when it hits the ground
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "ground") {
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
			gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0f;
		}

		// Show what button to press
		if (other.gameObject.tag == "Player" && limit == true) {
			UI.CanInteract (0);
		}
	}
	
	void OnTriggerStay2D(Collider2D other){
		// Checks if the player can spawn a brute
		if (other.gameObject.tag == "Player" && limit == true) {

			if (Input.GetKeyDown (KeyCode.DownArrow) && other.gameObject.tag == "Player" && GameMaster.activePlayer[0] && limit == true) {
				
				Instantiate (brutePrefab, bruteSpawner.position + new Vector3 (2f, 1f, 0f), bruteSpawner.rotation);

				CameraFollow2D.FindBrute ();

				limit = false;

				UI.CanInteract (1);
			}
		}
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			UI.CanInteract (1);
		}
	}
}
