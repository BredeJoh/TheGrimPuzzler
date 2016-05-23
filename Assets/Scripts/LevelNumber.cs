using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelNumber : MonoBehaviour {

	Text levelText;

	// Use this for initialization
	void Start () {

		levelText = GetComponent<Text> ();

			// Changing the text at the start of a scene according to the scene index
			levelText.text = ("Floor Number " + SceneManager.GetActiveScene().buildIndex);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
