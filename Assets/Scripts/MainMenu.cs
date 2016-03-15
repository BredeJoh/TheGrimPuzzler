using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	void Update (){
		if (Input.GetKeyDown(KeyCode.Return)){
			print ("-----Started Game-----");
			StartCoroutine(LoadNextLevel ());
		}
	}

	IEnumerator LoadNextLevel(){
		float fadeTime = GameObject.Find("Goal").GetComponent<Fading> ().BeginFade(1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel (Application.loadedLevel + 1);

	}

}
