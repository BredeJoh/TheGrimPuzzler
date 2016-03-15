using UnityEngine;
using System.Collections;

public class FallingObjects : MonoBehaviour {



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		
			Destroy (this.gameObject);

	}
}
