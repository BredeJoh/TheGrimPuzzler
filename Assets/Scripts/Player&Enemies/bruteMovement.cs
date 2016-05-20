using UnityEngine;
using System.Collections;

public class bruteMovement : MonoBehaviour
{

    Rigidbody2D body2D;
    GameObject playerBody2D;
    float speed = 3f;
    private bool moveRight = true;
    private float PlayerDistance = 100f;
    private float PlayerYDistance = 100f;
    private bool playerTooHigh = true;

    bool attack = false;

    public GameObject bruteSpawn;
    public GameObject skeleSpawn;
    public GameObject banshSpawn;

	Animator anim;

    // Use this for initialization
    void Start()
    {
		anim = gameObject.GetComponent<Animator> ();
        body2D = GetComponent<Rigidbody2D>();
        playerBody2D = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        PlayerDistance = gameObject.transform.position.x - playerBody2D.transform.position.x;
        PlayerYDistance = gameObject.transform.position.y - playerBody2D.transform.position.y;

        if (PlayerYDistance > 5 || PlayerYDistance < -5)
        {
            playerTooHigh = true;
   
        }
        else
        {
            playerTooHigh = false;
        }

        if (PlayerDistance <= 3f && PlayerDistance > -3f && playerTooHigh == false)
        {
			

            if (PlayerDistance > 0)
            {
                gameObject.transform.localScale = new Vector2(1f, 1f);
            }
            else if (PlayerDistance < 0)
            {
                gameObject.transform.localScale = new Vector2(-1f, 1f);
            }
            if (attack == false)
            {
				anim.SetInteger ("animationstate", 1);
                StartCoroutine(attackAndWait(3.0f));
            }
        }


        if (moveRight && (PlayerDistance > 3f || PlayerDistance < -3f || playerTooHigh == true))
        {
            body2D.velocity = new Vector2(speed, body2D.velocity.y);
            transform.localScale = new Vector2(-1f, 1f);
			anim.SetInteger ("animationstate", 0);

        }
        else if (moveRight == false && (PlayerDistance > 3f || PlayerDistance < -3f || playerTooHigh == true))
        {
            body2D.velocity = new Vector2(-speed, body2D.velocity.y);
            transform.localScale = new Vector2(1f, 1f);
			anim.SetInteger ("animationstate", 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "movementTrigger")
        {
            if (moveRight)
            {
                moveRight = false;
            }
            else
            {
                moveRight = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "crate" || other.gameObject.tag == "projectile")
        {

            if (gameObject.tag == "enemyBrute")
            {
                Instantiate(bruteSpawn, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
            else if (gameObject.tag == "enemySkele")
            {
                Instantiate(skeleSpawn, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
            else if (gameObject.tag == "enemyBanshee")
            {
                Instantiate(banshSpawn, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }

    IEnumerator attackAndWait(float WaitTime)
    {
        attack = true;
        anim.SetInteger("animationstate", 2);
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponentInChildren<EdgeCollider2D>().enabled = true;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponentInChildren<EdgeCollider2D>().enabled = false;
        yield return new WaitForSeconds(1f);
        anim.SetInteger("animationstate", 0);
        attack = false;
    }
}
