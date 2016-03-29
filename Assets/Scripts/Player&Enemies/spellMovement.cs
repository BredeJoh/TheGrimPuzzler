using UnityEngine;
using System.Collections;

public class spellMovement : MonoBehaviour {

    Rigidbody2D body2D;
    public int throwspeed = 8;
    float throwDirection;
    GameObject playerBody2D;
    GameObject banshee;

    // Use this for initialization
    void Start () {

        banshee = GameObject.FindGameObjectWithTag("banshee");
        playerBody2D = GameObject.FindGameObjectWithTag("Player");
        throwDirection = playerBody2D.transform.position.x - gameObject.transform.position.x;
        if (GameMaster.currentPlayerBanshee == true)
        {
            throwDirection = banshee.transform.localScale.x * -1;
        }

    }
	
	// Update is called once per frame
	void Update () {
    
        if (throwDirection > 0)
        {
            throwDirection = 1;
        }
        else
        {
            throwDirection = -1;
        }
        
        gameObject.transform.position = new Vector2((throwDirection/throwspeed) + gameObject.transform.position.x, gameObject.transform.position.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        Destroy(gameObject);
    }
}

