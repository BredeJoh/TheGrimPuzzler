﻿using UnityEngine;
using System.Collections;

// player controlled skeleton script

public class SkeletonController : MonoBehaviour
{

    float speed = 7.0f;
    float jumpSpeed = 14.0f;
    bool isGrounded = false;
    Rigidbody2D body2D;
    bool throws = false;
    public Transform firePoint;
    public Transform Bone_Projectileprefab;
    private bool climb = false;

    public GameObject deathParticle;

	Animator anim;

    // Use this for initialization
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();

		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (1, transform.position.y);

        firePoint = firePoint.transform;

		anim = gameObject.GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        // sets character kinamatic when not used
		if (isGrounded && GameMaster.activePlayer[1] == false)
        {
            body2D.isKinematic = true;
            anim.SetInteger("animationstate", 0);
        }
        else
        {
            body2D.isKinematic = false;
        }
        // plays only when player is controlling skeleton
		if (GameMaster.activePlayer[1] == true)
        {
            // Check if Skeleton exists

            // Movement
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                body2D.velocity = new Vector2(-speed, body2D.velocity.y);
                transform.localScale = new Vector2(1f, 1f);

				// Gå-animation hvis han er på bakken
				if(isGrounded){
				anim.SetInteger ("animationstate", 1);
				}
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                body2D.velocity = new Vector2(speed, body2D.velocity.y);
                transform.localScale = new Vector2(-1f, 1f);
				if(isGrounded){
					anim.SetInteger ("animationstate", 1);
				}
            }
            else {
                body2D.velocity = new Vector2(0f, body2D.velocity.y);

				// Kjør Idle-animation hvis han er på bakken
				if(isGrounded){
					anim.SetInteger ("animationstate", 0);
				}
            }
            // kills object
            if (Input.GetKey(KeyCode.S))
            {
                Destroy(gameObject);
            }

            // Jumping
            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
            {
                body2D.velocity = new Vector2(body2D.velocity.x, jumpSpeed);
                isGrounded = false;
				anim.SetInteger ("animationstate", 2);
            }
            // climbing
            else if (Input.GetKey(KeyCode.UpArrow) && climb == true)
            {
                body2D.velocity = new Vector2(body2D.velocity.x, speed);
                isGrounded = false;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (throws == false)
                {
                    StartCoroutine(attackAndWait(2.0f));
                }
            }
        }
        else {
          // gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, transform.position.y);
        }
    }
    //death conditions
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "spikes" || other.gameObject.tag == "projectile" || other.gameObject.tag == "enemyBanshee" || other.gameObject.tag == "enemySkele" || other.gameObject.tag == "enemyBrute")
        {
			Instantiate (deathParticle, transform.position, transform.rotation);
            GameMaster.KillSkeleton(this);
        }
    }
    // checks if grounded or can climb
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGrounded = true;
			anim.SetInteger ("animationstate", 0);
        }
        if (other.gameObject.tag == "ladder")
        {
            climb = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "ladder")
        {
            climb = false;
        }
        if (other.gameObject.tag == "ground")
        {
            isGrounded = false;
        }
    }
    // player controlled skeleton attack
    IEnumerator attackAndWait(float WaitTime)
    {
        throws = true;
        Instantiate(Bone_Projectileprefab, firePoint.position, gameObject.transform.rotation);
        yield return new WaitForSeconds(WaitTime);
        throws = false;
    }
}