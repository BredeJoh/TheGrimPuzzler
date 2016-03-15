using UnityEngine;
using System.Collections;

public class ActivateableDoor : MonoBehaviour {

	GameObject door;

	bool activated = true;

	void Start (){
		door = GameObject.FindGameObjectWithTag ("door");
	}

	void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.tag == "brute"){
			//Destroy (door);
			//door.GetComponent<SpriteRenderer>().enabled = !enabled;
			//door.GetComponent<BoxCollider2D>().enabled = !enabled;
			if (activated){
			StartCoroutine (PushDownPlate());
				activated = false;
			}
			//gameObject.GetComponent<BoxCollider2D> ().enabled = !gameObject.GetComponent<BoxCollider2D> ().enabled;
		}
	}

	IEnumerator PushDownPlate (){

		yield return new WaitForSeconds (1);
		door.GetComponent<SpriteRenderer>().enabled = !enabled;
		door.GetComponent<BoxCollider2D>().enabled = !enabled;
		gameObject.GetComponent<EdgeCollider2D> ().enabled = !enabled;
		transform.position = new Vector2 (transform.position.x, transform.position.y-1);


	}
}
