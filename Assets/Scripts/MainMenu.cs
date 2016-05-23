using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	void Update (){
		if (Input.GetKeyDown(KeyCode.Return)){
			print ("-----Started Game-----");
			StartCoroutine(LoadNextLevel ());
		}
	}

	// Loading the next scene
	IEnumerator LoadNextLevel(){
		float fadeTime = GameObject.Find("Goal").GetComponent<Fading> ().BeginFade(1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene ("First_Level");

	}

}
