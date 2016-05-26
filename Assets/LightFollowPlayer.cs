using UnityEngine;
using System.Collections;

public class LightFollowPlayer : MonoBehaviour {

    GameObject Player;

	// Use this for initialization
	void Start () {
	
        Player = GameObject.FindGameObjectWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.position = Player.transform.position + new Vector3(0f, 0f, -4f);

	}
}
