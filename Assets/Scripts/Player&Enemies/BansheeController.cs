using UnityEngine;
using System.Collections;

public class BansheeController : MonoBehaviour {

	float speed = 7.0f; 
	float jumpSpeed = 8.0f;
	bool isGrounded = false;
	Rigidbody2D body2D;
    public Transform firePoint;
    public Transform Bone_Projectileprefab;
    bool throws = false;
    private bool climb = false;

	Animator anim;

    // Use this for initialization
    void Start () {
		body2D = GetComponent<Rigidbody2D> ();
        firePoint = firePoint.transform;
		anim = gameObject.GetComponent<Animator> ();
    }

	// Update is called once per frame
	void Update () {
        // sets character kinamatic when not used
        if (isGrounded && GameMaster.activePlayer[3] == false)
        {
            body2D.isKinematic = true;
        }
        else
        {
            body2D.isKinematic = false;
        }
        // plays only when player is controlling banshee
        if (GameMaster.activePlayer[3] == true) {
			// Check if Banshee exists

            
			// Movement
			if (Input.GetKey (KeyCode.LeftArrow)) {
				anim.SetInteger ("animationstate", 1);
				body2D.velocity = new Vector2 (-speed, body2D.velocity.y);
				transform.localScale = new Vector2 (1f, 1f);
			} else if (Input.GetKey (KeyCode.RightArrow)) {
				anim.SetInteger ("animationstate", 1);
				body2D.velocity = new Vector2 (speed, body2D.velocity.y);
				transform.localScale = new Vector2 (-1f, 1f);
			} else {
				anim.SetInteger ("animationstate", 0);
				body2D.velocity = new Vector2 (0f, body2D.velocity.y);
			}
            // kills object
            if (Input.GetKey(KeyCode.S))
            {
				GameMaster.KillBanshee (this);
            }

            // Jumping
            if (Input.GetKeyDown (KeyCode.UpArrow) && isGrounded == true) {
				body2D.velocity = new Vector2 (body2D.velocity.x, jumpSpeed);
				isGrounded = false;
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
        } else {
			//gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (0,transform.position.y);
		}
	}
    // Death conditions
    void OnCollisionEnter2D(Collision2D other){
		
        if (other.gameObject.tag == "projectile" || other.gameObject.tag == "enemyBanshee" || other.gameObject.tag == "enemySkele" || other.gameObject.tag == "enemyBrute")
        {
			GameMaster.KillBanshee (this);
        }
	}
    // checks if player can jump or climb
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "ground" || other.gameObject.tag == "spikes"){
			isGrounded = true;
		}
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "ladder")
        {
            climb = true;
        }
		if (other.gameObject.tag == "ground" || other.gameObject.tag == "spikes"){
			isGrounded = true;
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
    // player controlled banshee attack
    IEnumerator attackAndWait(float WaitTime)
    {
        throws = true;
        if (gameObject.transform.localScale.x == 1)
        {
            Instantiate(Bone_Projectileprefab, firePoint.position, Quaternion.Euler(0, 0, 180));
        }
        else
        {
            Instantiate(Bone_Projectileprefab, firePoint.position, Quaternion.Euler(0, 0, 0));
        }
        yield return new WaitForSeconds(WaitTime);
        throws = false;
    }
}
