using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {

	// Texture used for fading
	public Texture2D fadeOutTexture;
	// The speed at which the texture fades in
	public float fadeSpeed = 0.8f;
	
	int drawDepth = -1000;
	float alpha = 1.0f;
	int fadeDir = -1;
	
	void OnGUI(){

		// Adjusts the alpha of the texture over time
		alpha += fadeDir * fadeSpeed * Time.deltaTime;

		// Setting alpha to a value between 0-1 (0 alpha = min, 1 alpha = max)
		alpha = Mathf.Clamp01 (alpha);

		// Drawing the texture on the GUI
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);
	}
	public float BeginFade (int direction) {
		fadeDir = direction;
		return (fadeSpeed);
	}
	// Begins when a scene is loaded
	void OnLevelWasLoaded(){
		
		BeginFade (-1);

	}
}

