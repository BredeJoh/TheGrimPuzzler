using UnityEngine;
using System.Collections;

public class DeleteParticles : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(DestroyParticle ());
	}

	// Sletter partikklen etter den har gjort sitt
	IEnumerator DestroyParticle (){
		
		yield return new WaitForSeconds (3);
		Destroy (gameObject);
	}
}
