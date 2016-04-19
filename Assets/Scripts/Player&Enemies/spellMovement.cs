using UnityEngine;
using System.Collections;

public class spellMovement : MonoBehaviour {

    public int throwspeed = 8;
    public float throwDirection = 0f;
    GameObject banshee;

    // Use this for initialization
    void Start() {

        banshee = GameObject.FindGameObjectWithTag("banshee");
        if (gameObject.transform.rotation == Quaternion.Euler(0, 0, 180))
        {
            throwDirection = -1f;
        }
        else
        {
            throwDirection = 1f;
        }
        if (GameMaster.currentPlayerBanshee == true)
        {
            throwDirection = banshee.transform.localScale.x * -1;
        }
        StartCoroutine(Dissapear());

    }
	
	// Update is called once per frame
	void Update () {
    
        if (throwDirection > 0)
        {
            throwDirection = 1f;
        }
        else if (throwDirection < 0)
        {
            throwDirection = -1f;
        }
        
        gameObject.transform.position = new Vector2((throwDirection/throwspeed) + gameObject.transform.position.x, gameObject.transform.position.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {

       // Destroy(gameObject);
    }
    
    IEnumerator Dissapear()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}

