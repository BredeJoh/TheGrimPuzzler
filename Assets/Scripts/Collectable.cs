using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player"){
			GameMaster.collectables += 1;
			Destroy (this.gameObject);
		}
	}
}