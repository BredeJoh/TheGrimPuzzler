using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkeleSpawner : MonoBehaviour {

	public Transform skeletonPrefab;
	public Transform skeletonSpawner;
	public Transform currentSkeleton;

	Text skeleton;

	float nextTimeToSearch = 0;
	public bool limit;

	// Use this for initialization
	void Start () {
		skeleton = GameObject.Find ("ActiveSkeleton").GetComponent<Text> ();

		limit = true;
	}

	void FixedUpdate(){

		if (currentSkeleton == null) {
			limit = true;

			if (nextTimeToSearch <= Time.time) {
				GameObject searchResult = GameObject.FindGameObjectWithTag ("skeleton");	
				if (searchResult != null){
					currentSkeleton = searchResult.transform;
				limit = false;
				nextTimeToSearch = Time.time + 0.5f;
				}
				}
			}
		}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "ground"){
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f,0f);
		gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0f;
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Player"){

			// Show what button to press

			if(Input.GetKeyDown(KeyCode.DownArrow) && limit == true){

				Instantiate(skeletonPrefab, skeletonSpawner.position, skeletonSpawner.rotation);
				skeleton.enabled = enabled;
				limit = false;

			}
		}
	}
}
