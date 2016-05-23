using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Transform spawnpoint;

	float speed = 7.0f; 
	float jumpSpeed = 14.0f;
	bool isGrounded = false;
    bool stunned = false;
    private bool climb = false;
	Rigidbody2D body2D;

	Animator anim;

	// Use this for initialization
	void Start () {
        // moves player to spawnpoint at the start of a level
		transform.position = spawnpoint.position;
		body2D = GetComponent<Rigidbody2D> ();

		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

        // sets player as kinematick if inactive (player is controlling enemy)
		if (isGrounded && GameMaster.activePlayer[0] == false)
        {
            body2D.isKinematic = true;
            anim.SetInteger("animationstate", 0);
        }
        else
        {
            body2D.isKinematic = false;
        }

		// Checkes if the player is active and not in a "stunned" state
		if (GameMaster.activePlayer[0] == true && stunned == false) {
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

            // Jumping
            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true && climb == false) {
				body2D.velocity = new Vector2 (body2D.velocity.x, jumpSpeed);
				isGrounded = false;
			}
            //climbing
            else if (Input.GetKey(KeyCode.UpArrow) && climb == true)
            {
                body2D.velocity = new Vector2(body2D.velocity.x, speed);
                isGrounded = false;
            }
		} else {
			//gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (0,0);
		}
        if (isGrounded)
        {
            stunned = false;
        }
	}

    // Stuns and knockback to player
	void OnCollisionStay2D (Collision2D other){
        if (other.gameObject.tag == "enemySkele" || other.gameObject.tag == "projectile" || other.gameObject.tag == "enemyBrute" || other.gameObject.tag == "enemyBanshee") 
        {
            stunned = true;
            Vector2 knockBack = other.gameObject.transform.position - gameObject.transform.position;
            if (knockBack.x > 0)
            {
                // Destroy projectiles if hit
                body2D.velocity = new Vector2(-speed, speed);
                if (other.gameObject.tag == "projectile")
                {
                    Destroy(other.gameObject);
                }
            }
            else
            {
                body2D.velocity = new Vector2(speed, speed);
                if (other.gameObject.tag == "projectile")
                {
                    Destroy(other.gameObject);
                }
            }
        }
        
    }
    // stun and knockback for trigger attacks (brute)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemySkele" || other.gameObject.tag == "projectile" || other.gameObject.tag == "enemyBrute" || other.gameObject.tag == "enemyBanshee")
        {
            stunned = true;
            Vector2 knockBack = other.gameObject.transform.position - gameObject.transform.position;
            if (knockBack.x > 0)
            {

                body2D.velocity = new Vector2(-speed, speed);
                if (other.gameObject.tag == "projectile")
                {
                    Destroy(other.gameObject);
                }
            }
            else
            {
                body2D.velocity = new Vector2(speed, speed);
                if (other.gameObject.tag == "projectile")
                {
                    Destroy(other.gameObject);
                }
            }
        }

    }

    // checks if layer can jump, climb or is on moving platform
    void OnTriggerStay2D(Collider2D other)
    {
		if (other.gameObject.tag == "ground")
		{
			isGrounded = true;
		}   

        if (other.gameObject.tag == "ladder")
        {
            climb = true;
        }

        if (other.gameObject.tag == "platform")
        {
            transform.parent = other.transform;
        }


    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "ladder")
        {
            climb = false;
        }
		if (other.gameObject.tag == "ground"){
			isGrounded = false;        
        }
        if (other.gameObject.tag == "platform")
        {
            transform.parent = null;
        }
    }

}
