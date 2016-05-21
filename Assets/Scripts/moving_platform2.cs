using UnityEngine;
using System.Collections;

public class moving_platform2 : MonoBehaviour
{

    public float speed = 0.03f;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.position = new Vector2(gameObject.transform.position.x + speed, gameObject.transform.position.y);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("hei");
        if (other.gameObject.tag == "movementTrigger")
        {
            print("hei");
            speed *= -1f;
        }
    }
}
