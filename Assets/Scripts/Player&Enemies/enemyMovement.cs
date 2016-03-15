using UnityEngine;
using System.Collections;

public class enemyMovement : MonoBehaviour {

    Rigidbody2D body2D;
    float speed = 3f;
    private bool moveRight = true;

	public GameObject bruteSpawn;
	public GameObject skeleSpawn;
	public GameObject banshSpawn;

	// Use this for initialization
	void Start () {
        body2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (moveRight)
        {
            body2D.velocity = new Vector2(speed, body2D.velocity.y);
            transform.localScale = new Vector2(-1f, 1f);
            
        }
        else if (moveRight == false)
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
}
