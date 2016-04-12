using UnityEngine;
using System.Collections;

public class SkeletonController : MonoBehaviour
{

    float speed = 7.0f;
    float jumpSpeed = 14.0f;
    bool isGrounded = false;
    Rigidbody2D body2D;
    bool throws = false;
    public Transform firePoint;
    public Transform Bone_Projectileprefab;

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
        if (GameMaster.currentPlayerSkeleton == true)
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "spikes" || other.gameObject.tag == "projectile" || other.gameObject.tag == "enemyBanshee" || other.gameObject.tag == "enemySkele" || other.gameObject.tag == "enemyBrute")
        {
			Instantiate (deathParticle, transform.position, transform.rotation);
            GameMaster.KillSkeleton(this);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGrounded = true;
			anim.SetInteger ("animationstate", 0);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGrounded = false;
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