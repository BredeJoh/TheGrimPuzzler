using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	public Image[] uiImage;

	GameObject[] activePlayer;

	float nextTimeToSearch = 0;

	// Use this for initialization
	void Start () {
		for (int i=0; i<7; i++){
			if (i == 3 || i == 4) {
				uiImage [i].GetComponent<CanvasGroup> ().alpha = 1f;
			} else {
				uiImage [i].GetComponent<CanvasGroup> ().alpha = 0.5f;
			}
		}

		activePlayer = new GameObject[3];

	}
	
	// Update is called once per frame
	void Update () {

		// Sjekker om du har en hjelper i scena
		if (activePlayer[0] == null){
			uiImage [0].GetComponent<CanvasGroup> ().alpha = 0.5f;
			FindSkeleton ();
		} else {
			SkeletonIsActive ();
		}
		if (activePlayer[1] == null){
			uiImage [1].GetComponent<CanvasGroup> ().alpha = 0.5f;
			FindBrute ();
		} else {
			BruteIsActive ();
		} 
		if (activePlayer[2] == null){
			uiImage [2].GetComponent<CanvasGroup> ().alpha = 0.5f;
			FindBanshee ();
		} else {
			BansheeIsActive ();
		}

		// Viser hvilken karakter du kontrollerer
		if (GameMaster.currentPlayerSkeleton) {
			uiImage [0].GetComponent<Image> ().color = Color.green;
			uiImage [5].GetComponent<CanvasGroup> ().alpha = 1f;
			uiImage [6].GetComponent<CanvasGroup> ().alpha = 1f;
		} else {
			uiImage [0].GetComponent<Image> ().color = Color.white;
		}
		if (GameMaster.currentPlayerBrute) {
			uiImage [1].GetComponent<Image> ().color = Color.blue;
			uiImage [5].GetComponent<CanvasGroup> ().alpha = 1f;
			uiImage [6].GetComponent<CanvasGroup> ().alpha = 1f;
		} else {
			uiImage [1].GetComponent<Image> ().color = Color.white;
		}
		if (GameMaster.currentPlayerBanshee) {
			uiImage [2].GetComponent<Image> ().color = Color.red;
			uiImage [5].GetComponent<CanvasGroup> ().alpha = 1f;
			uiImage [6].GetComponent<CanvasGroup> ().alpha = 1f;
		} else {
			uiImage [2].GetComponent<Image> ().color = Color.white;
		}
		if (GameMaster.currentPlayer){
			uiImage [5].GetComponent<CanvasGroup> ().alpha = 0.5f;
		}
	}

	// Lyse opp knappen hvis en av de er i scena
	void SkeletonIsActive (){
		uiImage [0].GetComponent<CanvasGroup> ().alpha = 1f;
	}
	void BruteIsActive (){
		uiImage [1].GetComponent<CanvasGroup> ().alpha = 1f;
	}
	void BansheeIsActive (){
		uiImage [2].GetComponent<CanvasGroup> ().alpha = 1f;
	}

	// Prøver å finne skeleton
	void FindSkeleton () {
		if (nextTimeToSearch <= Time.time) {
			GameObject searchResult = GameObject.FindGameObjectWithTag ("skeleton");	
			if (searchResult != null)
				activePlayer[0] = searchResult;
			nextTimeToSearch = Time.time + 0.5f;
		}
	}

	// Prøver å finne brute
	void FindBrute () {
		if (nextTimeToSearch <= Time.time) {
			GameObject searchResult = GameObject.FindGameObjectWithTag ("brute");	
			if (searchResult != null)
				activePlayer[1] = searchResult;
			nextTimeToSearch = Time.time + 0.5f;
		}
	}

	// Prøver å finne banshee
	void FindBanshee (){
		if (nextTimeToSearch <= Time.time) {
			GameObject searchResult = GameObject.FindGameObjectWithTag ("banshee");	
			if (searchResult != null)
				activePlayer[2] = searchResult;
			nextTimeToSearch = Time.time + 0.5f;
		}
	}
}