using UnityEngine;
using System.Collections;

public class GetOverSpikes : MonoBehaviour {

	public GameObject ground;
	public Transform groundSpawn;

	// Use this for initialization
	void Start () {
		Instantiate (ground, groundSpawn.position, groundSpawn.rotation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.tag == "banshee" && Input.GetKeyDown(KeyCode.DownArrow)){
			GameObject.FindGameObjectWithTag ("spikeBridge").GetComponent<Rigidbody2D> ().gravityScale = 1;
			GameObject.FindGameObjectWithTag ("spikeBridge").tag = "ground";
			gameObject.GetComponent<BoxCollider2D> ().enabled = !gameObject.GetComponent<BoxCollider2D> ().enabled;
		}
	}
}
