using UnityEngine;
using System.Collections;

public class MovingWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.position += new Vector3(0.02f, 0f, 0f);

	}
}
