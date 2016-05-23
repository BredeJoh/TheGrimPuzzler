using UnityEngine;
using System.Collections;

public class healthPickup : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other){

		// Destroys itself when the player picks them up
		if (other.gameObject.tag == "Player"){
			Destroy (this.gameObject);
		}
	}
}
