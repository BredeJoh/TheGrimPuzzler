using UnityEngine;
using System.Collections;

public class enemyMovement : MonoBehaviour {

    Rigidbody2D body2D;
    public Transform firePoint;
    GameObject playerBody2D;
    float speed = 3f;
    private bool moveRight = true;
    private float PlayerDistance = 100f;

    bool throws = false;

	public GameObject bruteSpawn;
	public GameObject skeleSpawn;
	public GameObject banshSpawn;
    public Transform Bone_Projectileprefab;

	// Use this for initialization
	void Start () {
        body2D = GetComponent<Rigidbody2D>();
        playerBody2D = GameObject.FindGameObjectWithTag("Player");
        firePoint = firePoint.transform;

    }

    // Update is called once per frame
    void Update()
    {
        PlayerDistance = gameObject.transform.position.x - playerBody2D.transform.position.x;

        if (PlayerDistance <= 10f && PlayerDistance > -10f)
        {

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


        if (moveRight && (PlayerDistance > 10f || PlayerDistance < -10f))
            {
                body2D.velocity = new Vector2(speed, body2D.velocity.y);
                transform.localScale = new Vector2(-1f, 1f);

            }
            else if (moveRight == false && (PlayerDistance > 10f || PlayerDistance < -10f))
            {
                body2D.velocity = new Vector2(-speed, body2D.velocity.y);
                transform.localScale = new Vector2(1f, 1f);
            }
        }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "movementTrigger")
        {
            if (moveRight) {
                moveRight = false;
            }
            else
            {
                moveRight = true;
            }
        }
    }

	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "crate"){

		if (gameObject.tag == "enemyBrute"){
			Instantiate(bruteSpawn, transform.position, transform.rotation);
			Destroy (this.gameObject);
		} else if (gameObject.tag == "enemySkele"){
			Instantiate(skeleSpawn, transform.position, transform.rotation);
			Destroy (this.gameObject);
		} else if (gameObject.tag == "enemyBanshee"){
			Instantiate (banshSpawn, transform.position, transform.rotation);
			Destroy (this.gameObject);
		}
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
