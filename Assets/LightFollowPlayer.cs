using UnityEngine;
using System.Collections;

public class LightFollowPlayer : MonoBehaviour {

    GameObject camera;

	// Use this for initialization
	void Start () {
	
        camera = GameObject.Find("Main Camera");

    }
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.position = camera.transform.position + new Vector3(0f, 0f, 6f);

	}
}
