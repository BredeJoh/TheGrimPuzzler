using UnityEngine;
using System.Collections;

public class PushCrate : MonoBehaviour {

	//bool canMove;

	// Use this for initialization
	void Start () {
		// Setting mass to 1000
		gameObject.GetComponent<Rigidbody2D> ().mass = 1000;
	}

	// Checking if brute is pushing the object
	void OnCollisionStay2D (Collision2D other){
		if (other.gameObject.tag == "brute"){
			SettMass (300);
		}
	}

	// Resetting the mass if the brute is not in contact
	void OnCollisionExit2D (Collision2D other){
		SettMass (1000);
	}
		
	void SettMass (int massIn){
		gameObject.GetComponent<Rigidbody2D> ().mass = massIn;
	}
}
