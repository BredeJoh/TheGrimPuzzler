using UnityEngine;
using System.Collections;

public class moving_platform2 : MonoBehaviour
{

    public float speed = 0.03f;
    bool dontTurn = false;
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
        if (other.gameObject.tag == "movementTrigger" && dontTurn == false)
        {
            speed *= -1f;
            dontTurn = true;
            StartCoroutine(Wait(2.0f));
        }
    }

    IEnumerator Wait(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        dontTurn = false;
    }

}
