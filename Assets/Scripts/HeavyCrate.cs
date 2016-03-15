using UnityEngine;
using System.Collections;

public class HeavyCrate : MonoBehaviour {

	Transform brute;
	bool isMoving;

	void Update (){
		while(!isMoving){
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		}  
		while (isMoving){

		}
	}

	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "brute"){
			isMoving = true;
		}
	}

	void OnCollisionExit2D (Collision2D other){
		if (other.gameObject.tag == "brute"){
			isMoving = false;
		}
	}


}
