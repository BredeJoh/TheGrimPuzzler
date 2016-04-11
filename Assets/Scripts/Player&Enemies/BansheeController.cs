﻿using UnityEngine;
using System.Collections;

public class BansheeController : MonoBehaviour {

	float speed = 7.0f; 
	float jumpSpeed = 8.0f;
	bool isGrounded = false;
	Rigidbody2D body2D;
    public Transform firePoint;
    public Transform Bone_Projectileprefab;
    bool throws = false;
    // Use this for initialization
    void Start () {
		body2D = GetComponent<Rigidbody2D> ();
        firePoint = firePoint.transform;
    }

	// Update is called once per frame
	void Update () {
		if (GameMaster.currentPlayerBanshee == true) {
			// Check if Skeleton exists

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
            if (Input.GetKey(KeyCode.S))
            {
                Destroy(gameObject);
            }

            // Jumping
            if (Input.GetKeyDown (KeyCode.UpArrow) && isGrounded == true) {
				body2D.velocity = new Vector2 (body2D.velocity.x, jumpSpeed);
				isGrounded = false;
			}
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (throws == false)
                {
                    StartCoroutine(attackAndWait(2.0f));
                }
            }
        } else {
			//gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (0,transform.position.y);
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "ground" || other.gameObject.tag == "spikes"){
			isGrounded = true;
		}
	}
    IEnumerator attackAndWait(float WaitTime)
    {
        throws = true;
        Instantiate(Bone_Projectileprefab, firePoint.position, gameObject.transform.rotation);
        yield return new WaitForSeconds(WaitTime);
        throws = false;
    }
}
