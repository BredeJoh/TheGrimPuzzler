using UnityEngine;
using System.Collections;

public class spellMovement : MonoBehaviour {

    public int throwspeed = 8;
    public float throwDirection = 0f;
    GameObject banshee;

    // Use this for initialization
    void Start() {

        if (gameObject.transform.rotation == Quaternion.Euler(0, 0, 180))
        {
            throwDirection = -1f;
        }
        else
        {
            throwDirection = 1f;
        }
        StartCoroutine(Dissapear());

    }
	
	// Update is called once per frame
	void Update () {
    
        gameObject.transform.position = new Vector2((throwDirection/throwspeed) + gameObject.transform.position.x, gameObject.transform.position.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
       
    }
    
    IEnumerator Dissapear()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}

