using UnityEngine;
using System.Collections;

public class BoneScript : MonoBehaviour {


    Rigidbody2D body2D;
    public int throwspeed = 6;
    float throwDirection;
    GameObject playerBody2D;
    GameObject Skeleton;
    private Vector2 distance;


	// Use this for initialization
	void Start () {

        Skeleton = GameObject.FindGameObjectWithTag("skeleton");
        playerBody2D = GameObject.FindGameObjectWithTag("Player");
        throwDirection = playerBody2D.transform.position.x - gameObject.transform.position.x;

        if (throwDirection < 1.2f && throwDirection > 0f)
        {
            throwDirection -= 1.2f;
        }
        else if (throwDirection > -1.2f && throwDirection < 0f)
        {
            throwDirection += 1.2f;
        }

        if (throwDirection > 0)
        {
            throwDirection = 1;
        }
        else
        {
            throwDirection = -1;
        }
        if (GameMaster.currentPlayerSkeleton == true)
        {
            throwDirection = Skeleton.transform.localScale.x * -1f;
        }
        
            body2D = gameObject.GetComponent<Rigidbody2D>();
            body2D.velocity = new Vector2(throwDirection, 1f) * throwspeed;
        
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "projectile")
        {
            Destroy(gameObject);
        }
    }
}
