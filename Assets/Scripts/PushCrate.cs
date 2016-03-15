using UnityEngine;
using System.Collections;

public class PushCrate : MonoBehaviour {bool canMove;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody2D> ().mass = 1000;
	}

	void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.tag == "brute"){
			SettMass (30);
		}
	}

	void OnTriggerExit2D (Collider2D other){
		SettMass (300);
	}

	void SettMass (int massIn){
		gameObject.GetComponent<Rigidbody2D> ().mass = massIn;
	}
}
