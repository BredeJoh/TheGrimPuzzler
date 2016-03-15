using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BansheeSpawner : MonoBehaviour {

	public Transform bansheePrefab;
	public Transform bansheeSpawner;
	public Transform currentBanshee;

	Text banshee;

	float nextTimeToSearch = 0;
	public bool limit;

	// Use this for initialization
	void Start () {
		banshee = GameObject.Find ("ActiveBanshee").GetComponent<Text> ();

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
		if (other.gameObject.tag == "Player"){

			// Show what button to press

			if(Input.GetKeyDown(KeyCode.DownArrow) && limit == true){

				Instantiate(bansheePrefab, bansheeSpawner.position, bansheeSpawner.rotation);
				banshee.enabled = enabled;
				limit = false;

			}
		}
	}
}
