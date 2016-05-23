using UnityEngine;
using System.Collections;

public class BruteController : MonoBehaviour {

	float speed = 5.0f; 
	Rigidbody2D body2D;

	Animator anim;

	// Use this for initialization
	void Start () {
		body2D = GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
        // Check if Brute exists and is set as active character

		if (GameMaster.activePlayer[2] == true) {
			// Movement
			if (Input.GetKey (KeyCode.LeftArrow)) {
				body2D.velocity = new Vector2 (-speed, body2D.velocity.y);
				transform.localScale = new Vector2 (1f, 1f);
				anim.SetInteger ("animationstate", 1);
			} else if (Input.GetKey (KeyCode.RightArrow)) {
				body2D.velocity = new Vector2 (speed, body2D.velocity.y);
				transform.localScale = new Vector2 (-1f, 1f);
				anim.SetInteger ("animationstate", 1);
			} else {
				body2D.velocity = new Vector2 (0f, body2D.velocity.y);
				anim.SetInteger ("animationstate", 0);
			}
            // kills object
            if (Input.GetKey(KeyCode.S))
            {
                Destroy(gameObject);
            }
		} else {
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (0,0);
		}
	}
	// death conditions
	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.tag == "spikes" || other.gameObject.tag == "projectile" || other.gameObject.tag == "enemyBanshee" || other.gameObject.tag == "enemySkele" || other.gameObject.tag == "enemyBrute") {
			GameMaster.KillBrute(this);
		}
		if (other.gameObject.tag == "deadly") {
			GameMaster.KillBrute(this);
		}

	}
}
