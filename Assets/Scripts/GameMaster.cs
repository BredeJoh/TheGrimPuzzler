using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

	public static GameMaster gm;

	// What player is active
	// activePlayer[0]->Player, activePlayer[1]->Skeleton, activePlayer[2]->Brute, activePlayer[3]->Banshee
	public static bool[] activePlayer;

	public static int collectables;

	int spawnDelay = 1;

	public Transform playerPrefab;
	public Transform spawnPoint;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster>();

		activePlayer = new bool[4];
		for(int i=0; i<4; i++){
			activePlayer[i] = false;
		}
		activePlayer [0] = true;
	}

	void FixedUpdate(){
		transform.position = GameObject.FindGameObjectWithTag ("Player").transform.position;

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q) && !activePlayer[1] && CameraFollow2D.skeleton != null) {
			// Focus on Skeleton

			WhatPlayerIsActive (1);
		} else if (Input.GetKeyDown (KeyCode.Q) && activePlayer[1]) {
			// Focus on Player

			WhatPlayerIsActive (0);
		}
		if (Input.GetKeyDown (KeyCode.W) && !activePlayer[2] && CameraFollow2D.brute != null) {
			// Focus on Brute

			WhatPlayerIsActive (2);
		} else if (Input.GetKeyDown (KeyCode.W) && activePlayer[2]) {
			// Fucus on Player

			WhatPlayerIsActive (0);
		}
		if (Input.GetKeyDown (KeyCode.E) && !activePlayer[3] && CameraFollow2D.banshee != null) {
			// Focus on Banshee

			WhatPlayerIsActive (3);
		} else if (Input.GetKeyDown (KeyCode.E) && activePlayer[3]) {
			// Fucus on Player

			WhatPlayerIsActive (0);
		}
	}

	// Settin all players to false, and sending in what player that is currently active
	static void WhatPlayerIsActive(int x){
		for(int i=0; i<4; i++){
			activePlayer [i] = false;
		}
		activePlayer [x] = true;
	}
		
	public IEnumerator RespawnPlayer () {

		yield return new WaitForSeconds (spawnDelay);
	
		// Begynner å fade ut
		float fadeTime = GameObject.Find("Goal").GetComponent<Fading> ().BeginFade(1);

		// Venter med restart til etter fading er ferdig 
		yield return new WaitForSeconds (spawnDelay);

		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	public static void KillPlayer (Player player) {
		Destroy (player.gameObject);
		gm.StartCoroutine(gm.RespawnPlayer ());
	}
	public static void KillSkeleton (SkeletonController skeleton) {
		Destroy (skeleton.gameObject);

		WhatPlayerIsActive (0);
	}
	public static void KillBrute (BruteController brute){
		Destroy (brute.gameObject);

		WhatPlayerIsActive (0);
	} 
}

