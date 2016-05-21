﻿using UnityEngine;
using System.Collections;

public class moving_platform_vertical : MonoBehaviour {

    public float speed = 0.03f;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame  
    void Update()
    {

        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + speed);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "movementTrigger")
        {
            speed *= -1f;
        }
    }
}
