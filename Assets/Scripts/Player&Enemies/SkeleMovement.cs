﻿using UnityEngine;
using System.Collections;

public class SkeleMovement : MonoBehaviour
{

    Rigidbody2D body2D;
    public Transform firePoint;
    GameObject playerBody2D;
    float speed = 3f;
    private bool moveRight = true;
    public float PlayerDistance = 100f;
    private float PlayerYDistance = 100f;
    private bool playerTooHigh = true;

    bool throws = false;

    public GameObject bruteSpawn;
    public GameObject skeleSpawn;
    public GameObject banshSpawn;
    public Transform Bone_Projectileprefab;

    public GameObject[] deathParticle;

    Animator anim;

    // Use this for initialization
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        playerBody2D = GameObject.FindGameObjectWithTag("Player");
        firePoint = firePoint.transform;
        anim = gameObject.GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {
        // finds distance between player and object
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
        // turns towards player and attacks if close enough
        if (PlayerDistance <= 10f && PlayerDistance > -10f && playerTooHigh == false)
        {
          //  if (anim.GetInteger("animationstate") != 0)
           // {
                anim.SetInteger ("animationstate", 0);
          //  }
            if (PlayerDistance > 0)
            {
                gameObject.transform.localScale = new Vector2(1f, 1f);
            }
            else if (PlayerDistance < 0)
            {
                gameObject.transform.localScale = new Vector2(-1f, 1f);
            }
            if (throws == false)
            {
                StartCoroutine(attackAndWait(2.0f));
            }
        }

        // standard movement, left and right
        if (moveRight && (PlayerDistance > 10f || PlayerDistance < -10f || playerTooHigh == true))
        {
            body2D.velocity = new Vector2(speed, body2D.velocity.y);
            transform.localScale = new Vector2(-1f, 1f);
          //  if (anim.GetInteger("animationstate") != 1)
          //  {
                anim.SetInteger ("animationstate", 1);
           // }


        }
        else if (moveRight == false && (PlayerDistance > 10f || PlayerDistance < -10f || playerTooHigh == true))
        {
            body2D.velocity = new Vector2(-speed, body2D.velocity.y);
            transform.localScale = new Vector2(1f, 1f);
            //if (anim.GetInteger("animationstate") != 1)
           // {
                anim.SetInteger ("animationstate", 1);
          //  }
        }
    }
    // changes movedirection
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
    // death conditions
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "crate" || other.gameObject.tag == "projectile")
        {      
            
            Instantiate(deathParticle[0], transform.position, transform.rotation);
            Instantiate(skeleSpawn, transform.position, transform.rotation);
            Destroy(this.gameObject);
           
        }
    }
    // skeleton attack
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
