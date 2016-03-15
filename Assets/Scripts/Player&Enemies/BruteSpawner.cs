using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BruteSpawner : MonoBehaviour {

	public Transform brutePrefab;
	public Transform bruteSpawner;
	public Transform currentBrute;

	Text brute;
	
	float nextTimeToSearch = 0;
	public bool limit;
	
	// Use this for initialization
	void Start () {
		brute = GameObject.Find ("ActiveBrute").GetComponent<Text> ();

		limit = true;
	}
	
	void FixedUpdate(){
		
		if (currentBrute == null) {
			limit = true;
			
			if (nextTimeToSearch <= Time.time) {
				GameObject searchResult = GameObject.FindGameObjectWithTag ("brute");	
				if (searchResult != null){
					currentBrute = searchResult.transform;
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
				
				Instantiate(brutePrefab, bruteSpawner.position, bruteSpawner.rotation);
				brute.enabled = enabled;
				limit = false;
				
			}
		}
	}
}
