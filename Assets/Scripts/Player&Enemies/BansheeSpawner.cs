using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BansheeSpawner : MonoBehaviour {

	public Transform bansheePrefab;
	public Transform bansheeSpawner;
	public Transform currentBanshee;



	float nextTimeToSearch = 0;
	public bool limit;

	// Use this for initialization
	void Start () {
		

		limit = true;
	}

	void FixedUpdate(){

		if (currentBanshee == null) {
			limit = true;

			if (nextTimeToSearch <= Time.time) {
				GameObject searchResult = GameObject.FindGameObjectWithTag ("banshee");	
				if (searchResult != null){
					currentBanshee = searchResult.transform;
					limit = false;
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
		if (other.gameObject.tag == "Player" && limit == true) {

			if (Input.GetKeyDown (KeyCode.DownArrow) && other.gameObject.tag == "Player" && GameMaster.activePlayer[0] && limit == true) {

				Instantiate (bansheePrefab, bansheeSpawner.position + new Vector3 (2f, 1f, 0f), bansheeSpawner.rotation);

				CameraFollow2D.FindBanshee ();

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
