using UnityEngine;
using System.Collections;

public class moving_spikes : MonoBehaviour {


    public float speed = 1f;
    private bool moveUp = true;

	// Use this for initialization
	void Start () {
        StartCoroutine(move());
    }
	
	// Update is called once per frame
	void FixedUpdate () {
	
        if (moveUp)
        {
            gameObject.transform.position += new Vector3(0f, speed/50f, 0f);
        }
       

	}

    IEnumerator move()
    {

        yield return new WaitForSeconds(0.85f);
        moveUp = false;
        yield return new WaitForSeconds(2f);
        if (speed < 0)
        {
            yield return new WaitForSeconds(1f);
        }
        speed *= -1f;
        moveUp = true;
        StartCoroutine(move());
    }
}
