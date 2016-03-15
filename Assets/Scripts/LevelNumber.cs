using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelNumber : MonoBehaviour {

	//bool level1 = false;

	Text levelText;

	// Use this for initialization
	void Start () {

		levelText = GetComponent<Text> ();

		//level1 = true;

		//if (level1){
			levelText.text = ("Floor Number " + SceneManager.GetActiveScene().buildIndex);
		//}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
