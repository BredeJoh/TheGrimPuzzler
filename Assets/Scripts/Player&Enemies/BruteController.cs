using UnityEngine;
using System.Collections;

public class BruteController : MonoBehaviour {

	float speed = 5.0f; 
	Rigidbody2D body2D;
	
	// Use this for initialization
	void Start () {
		body2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		// Check if Brute exists

		if (GameMaster.currentPlayerBrute == true) {
			// Movement
			if (Input.GetKey (KeyCode.LeftArrow)) {
				body2D.velocity = new Vector2 (-speed, body2D.velocity.y);
				transform.localScale = new Vector2 (1f, 1f);
			} else if (Input.GetKey (KeyCode.RightArrow)) {
				body2D.velocity = new Vector2 (speed, body2D.velocity.y);
				transform.localScale = new Vector2 (-1f, 1f);
			} else {
				body2D.velocity = new Vector2 (0f, body2D.velocity.y);
			}
		} else {
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (0,0);
		}
	}
	
	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.tag == "spikes") {
			GameMaster.KillBrute(this);
		}
		if (other.gameObject.tag == "deadly") {
			GameMaster.KillBrute(this);
		}

	}
}
