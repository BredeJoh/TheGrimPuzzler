using UnityEngine;
using System.Collections;

public class DeleteParticles : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(DestroyParticle ());
	}

	// Sletter partikklen etter den har gjort sitt
	IEnumerator DestroyParticle (){

		// Destroys particles after a certain amount of time
		yield return new WaitForSeconds (3);
		Destroy (gameObject);
	}
}
