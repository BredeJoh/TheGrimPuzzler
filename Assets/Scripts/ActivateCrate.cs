using UnityEngine;
using System.Collections;

public class ActivateCrate : MonoBehaviour {

	public GameObject crate;
	public Transform crateSpawn;
	GameObject currentCrate;

	bool respawn = true;

	// Use this for initialization
	void Start () {
		//crateSpawn = GameObject.Find ("CrateSpawn").transform;
        currentCrate = Instantiate(crate, crateSpawn.position, crateSpawn.rotation) as GameObject;
        currentCrate.transform.parent = this.transform;
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
		if ((other.gameObject.tag == "Player" || other.gameObject.tag == "banshee")) {
			UI.CanInteract (0);

			if (Input.GetKeyDown (KeyCode.DownArrow)) {

				currentCrate.GetComponent<Rigidbody2D> ().gravityScale = 2;
				currentCrate.GetComponent<Rigidbody2D> ().isKinematic = false;

				gameObject.GetComponent<BoxCollider2D> ().enabled = !enabled;

			}
		} 
	}

	void OnTriggerExit2D (Collider2D other){

		if (other.gameObject.tag == "Player" || other.gameObject.tag == "banshee"){
			UI.CanInteract (1);
		}
	}

	// Respawning crate
	IEnumerator RespawnCrate (float waitIn){

		UI.CanInteract (1);
		Debug.Log ("---Respawning Crate---");
		yield return new WaitForSeconds (waitIn);
		Debug.Log ("---Waited for "+waitIn+" seconds");

        //Instantiate (crate, crateSpawn.position, crateSpawn.rotation);
        currentCrate = Instantiate(crate, crateSpawn.position, crateSpawn.rotation) as GameObject;
        currentCrate.transform.parent = this.transform;
        currentCrate.GetComponent<Rigidbody2D> ().gravityScale = 0;
		currentCrate.GetComponent<Rigidbody2D> ().isKinematic = true;
		respawn = true;
		gameObject.GetComponent<BoxCollider2D> ().enabled = enabled;
	}
}
