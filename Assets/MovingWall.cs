using UnityEngine;
using System.Collections;

public class MovingWall : MonoBehaviour {

    public float speedUp = 0f;
    public float speedSideWays = 0.03f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.position += new Vector3 (speedSideWays ,speedUp, 0f);

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            speedUp = -0.04f;
        }
    }
}
