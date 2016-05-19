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

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "ground") {
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
			gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0f;
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Player" && limit == true) {

			// Show what button to press
			UI.CanInteract (0);
		} else if (limit == false){
			UI.CanInteract (0);
		}
		if(Input.GetKeyDown(KeyCode.DownArrow) && other.gameObject.tag == "Player" && limit == true){

				Instantiate(bansheePrefab, bansheeSpawner.position + new Vector3 (2f, 1f, 0f), bansheeSpawner.rotation);

				CameraFollow2D.FindBanshee ();

				limit = false;

			}
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			UI.CanInteract (1);
		}
	}
}
