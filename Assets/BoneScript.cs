using UnityEngine;
using System.Collections;

public class BoneScript : MonoBehaviour {


    Rigidbody2D body2D;
    public int throwspeed = 6;
    float throwDirection;
    GameObject playerBody2D;

	// Use this for initialization
	void Start () {
        playerBody2D = GameObject.FindGameObjectWithTag("Player");
        throwDirection = playerBody2D.transform.position.x - gameObject.transform.position.x;
        if (throwDirection > 0)
        {
            throwDirection = 1;
        }
        else
        {
            throwDirection = -1;
        }
        body2D = gameObject.GetComponent<Rigidbody2D>();
        body2D.velocity = new Vector2(throwDirection, 1f) * throwspeed;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "ground")
        {
            Destroy(gameObject);
        }
    }
}
