using UnityEngine;
using System.Collections;

public class ActivateCrate : MonoBehaviour {

	public GameObject crate;
	Transform crateSpawn;
	GameObject currentCrate;

	bool respawn = true;

	// Use this for initialization
	void Start () {
		crateSpawn = GameObject.Find ("CrateSpawn").transform;
		Instantiate (crate, crateSpawn.position, crateSpawn.rotation);
		currentCrate = GameObject.FindGameObjectWithTag ("crate");
		currentCrate.GetComponent<Rigidbody2D> ().gravityScale = 0;
	}
	
	// Update is called once per frame
	void Update () {

		// Respawns Crate if it is not found
		if (currentCrate == null) {
			if (respawn){
			StartCoroutine (RespawnCrate(2));

			}
			respawn = false;
		}
	}

	void OnTriggerStay2D(Collider2D other){

		if ((other.gameObject.tag == "Player" || other.gameObject.tag == "banshee") && Input.GetKeyDown(KeyCode.DownArrow)){

			currentCrate.GetComponent<Rigidbody2D> ().gravityScale = 2;

			gameObject.GetComponent<BoxCollider2D>().enabled = !enabled;

		}
	}

	// Respawning crate
	IEnumerator RespawnCrate (float waitIn){

		Debug.Log ("---Respawning Crate---");
		yield return new WaitForSeconds (waitIn);
		Debug.Log ("---Waited for "+waitIn+" seconds");

		Instantiate (crate, crateSpawn.position, crateSpawn.rotation);
		currentCrate = GameObject.FindGameObjectWithTag ("crate");
		currentCrate.GetComponent<Rigidbody2D> ().gravityScale = 0;
		respawn = true;
		gameObject.GetComponent<BoxCollider2D> ().enabled = enabled;
	}
}
