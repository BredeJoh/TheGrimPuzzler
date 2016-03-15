using UnityEngine;
using System.Collections;

public class Ladder_fix : MonoBehaviour {

    public bool active = false;
    public GameObject ladder;
    public Sprite sprite;
	// Use this for initialization
	void Start () {
        ladder = GameObject.Find("ladder");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && other.gameObject.tag == "skeleton" && active == false)
        {
            active = true;
            ladder.GetComponent<SpriteRenderer>().sprite = sprite;
            ladder.tag = "ladder";


        }
    }
}
