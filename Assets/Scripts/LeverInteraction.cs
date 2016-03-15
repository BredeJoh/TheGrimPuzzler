using UnityEngine;
using System.Collections;

public class LeverInteraction : MonoBehaviour {

    public bool active;
    public GameObject bridge;
	// Use this for initialization
	void Start () {
        active = false;
        bridge = GameObject.Find("bridge");
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && other.gameObject.tag == "skeleton" && active == false)
        {
            bridge.GetComponent<HingeJoint2D>().useMotor = true;
            bridge.GetComponent<HingeJoint2D>().useLimits = false;
            
            active = true;
            bridge.tag = "ground";
        }
    }
}
