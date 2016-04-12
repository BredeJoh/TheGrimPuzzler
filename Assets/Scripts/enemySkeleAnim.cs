using UnityEngine;
using System.Collections;

public class enemySkeleAnim : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponent<Rigidbody2D> ().velocity != null) {
			anim.SetInteger ("animationstate", 1);
		} else {
			anim.SetInteger ("animationstate", 0);
		}

	}
}
