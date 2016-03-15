using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelNumber : MonoBehaviour {

	bool level1 = false;

	Text levelText;

	// Use this for initialization
	void Start () {

		levelText = GetComponent<Text> ();

		level1 = true;

		if (level1){
			levelText.text = "Floor Number";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
