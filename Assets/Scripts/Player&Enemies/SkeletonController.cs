using UnityEngine;
using System.Collections;

public class SkeletonController : MonoBehaviour
{

    float speed = 7.0f;
    float jumpSpeed = 12.0f;
    bool isGrounded = false;
    Rigidbody2D body2D;

    // Use this for initialization
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
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
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                body2D.velocity = new Vector2(speed, body2D.velocity.y);
                transform.localScale = new Vector2(-1f, 1f);
            }
            else {
                body2D.velocity = new Vector2(0f, body2D.velocity.y);
            }

            // Jumping
            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
            {
                body2D.velocity = new Vector2(body2D.velocity.x, jumpSpeed);
                isGrounded = false;
            }
        }
        else {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, transform.position.y);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "spikes")
        {
            GameMaster.KillSkeleton(this);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGrounded = false;
        }
    }
}