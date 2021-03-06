﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	// Array for the displayed UI images
	public Image[] uiImage;

	// Array for the original UI
	public Sprite[] originalUI;

	// Array for images for UI colorchange
	public Sprite[] colorUI;

	// Array for the tutorial texts
	public Image[] sign;

	static bool interactable = false;

	// Use this for initialization
	void Start () {
		for (int i=0; i<7; i++){
			if (i == 3) {
				uiImage [i].GetComponent<CanvasGroup> ().alpha = 1f;
			} else {
				uiImage [i].GetComponent<CanvasGroup> ().alpha = 0.5f;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		// Sjekker om du har en hjelper i scena
		if (CameraFollow2D.skeleton != null) {
			SkeletonIsActive ();
		} else {
			uiImage [0].GetComponent<CanvasGroup> ().alpha = 0.5f;
		}
		if (CameraFollow2D.brute != null){
			BruteIsActive ();
		} else {
			uiImage [1].GetComponent<CanvasGroup> ().alpha = 0.5f;
		} 
		if (CameraFollow2D.banshee != null){
			BansheeIsActive ();
		} else {
			uiImage [2].GetComponent<CanvasGroup> ().alpha = 0.5f;
		}

		// Shows what character you control
		if (GameMaster.activePlayer[1]) {
			// Change image
			uiImage [0].GetComponent<Image>().sprite = colorUI[0];
			uiImage [5].GetComponent<CanvasGroup> ().alpha = 1f;
			uiImage [6].GetComponent<CanvasGroup> ().alpha = 1f;
		} else {
			// Changing back to the original sprite
			uiImage [0].GetComponent<Image>().sprite = originalUI[0];
		}
		if (GameMaster.activePlayer[2]) {
			uiImage [1].GetComponent<Image> ().sprite = colorUI[1];
			uiImage [5].GetComponent<CanvasGroup> ().alpha = 1f;
			uiImage [6].GetComponent<CanvasGroup> ().alpha = 1f;
		} else {
			uiImage [1].GetComponent<Image> ().sprite = originalUI[1];
		}
		if (GameMaster.activePlayer[3]) {
			uiImage [2].GetComponent<Image> ().sprite = colorUI[2];
			uiImage [5].GetComponent<CanvasGroup> ().alpha = 1f;
			uiImage [6].GetComponent<CanvasGroup> ().alpha = 1f;
		} else {
			uiImage [2].GetComponent<Image> ().sprite = originalUI[2];
		}
		if (GameMaster.activePlayer[0]){
			uiImage [5].GetComponent<CanvasGroup> ().alpha = 0.5f;
			uiImage [6].GetComponent<CanvasGroup> ().alpha = 0.5f;
		}

		if (interactable == true && (GameMaster.activePlayer[0] || GameMaster.activePlayer[1])) {
			uiImage [4].GetComponent<CanvasGroup> ().alpha = 1f;
		} else if (interactable == false){
			uiImage [4].GetComponent<CanvasGroup> ().alpha = 0.5f;
		}
	}

	// Show sign
	public void WhatSignToShow (int x){
		if (x == 2) {
			// Hiding all signs 
			for (int i = 0; i < 3; i++) {
				sign [i].GetComponent<CanvasGroup> ().alpha = 0;
			}
		} else {
			sign [x].GetComponent<CanvasGroup> ().alpha = 1;
		}
	}

	// Light the buttons if they are in the scene
	void SkeletonIsActive (){
		uiImage [0].GetComponent<CanvasGroup> ().alpha = 1f;
	}
	void BruteIsActive (){
		uiImage [1].GetComponent<CanvasGroup> ().alpha = 1f;
	}
	void BansheeIsActive (){
		uiImage [2].GetComponent<CanvasGroup> ().alpha = 1f;
	}

	// Checks if the player can interact with the object
	public static void CanInteract (int tallIn){
		if (tallIn == 0) {
			interactable = true;
		} else  if (tallIn == 1){
			interactable = false;
		}
	}
}