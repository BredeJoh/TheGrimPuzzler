using UnityEngine;
using System.Collections;

public class ActivateableDoor : MonoBehaviour {

	GameObject door;

	bool activated = true;

	void Start (){
		// Finds the door
		door = GameObject.FindGameObjectWithTag ("door");
	}

	void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.tag == "brute"){
			if (activated){
			StartCoroutine (PushDownPlate());
				activated = false;
			}
		}
	}

	// Waiting before pushing down the plate and disable the door
	IEnumerator PushDownPlate (){

		yield return new WaitForSeconds (1);
		door.GetComponent<SpriteRenderer>().enabled = !enabled;
		door.GetComponent<BoxCollider2D>().enabled = !enabled;
		gameObject.GetComponent<EdgeCollider2D> ().enabled = !enabled;
		transform.position = new Vector2 (transform.position.x, transform.position.y-1);


	}
}
