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

	// Variable for delaying a respawn
	int spawnDelay = 1;

	// Prefabs for the Player and its startpoint
	public Transform playerPrefab;
	public Transform spawnPoint;

	// Use this for initialization
	void Start () {
		// Finding the GameMaster
		gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster>();

		// Setting up the array for what player is active
		activePlayer = new bool[4];
		for(int i=0; i<4; i++){
			activePlayer[i] = false;
		}
		activePlayer [0] = true;
	}

	void FixedUpdate(){
		//transform.position = GameObject.FindGameObjectWithTag ("Player").transform.position;
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

	// Setting all players to false, and sending in what player that is currently active
	static void WhatPlayerIsActive(int x){
		for(int i=0; i<4; i++){
			activePlayer [i] = false;
		}
		activePlayer [x] = true;
	}
		
	public IEnumerator RespawnPlayer () {

		// Waits a bit before fading out
		yield return new WaitForSeconds (spawnDelay);

		// Beginning fade out
		float fadeTime = GameObject.Find("Goal").GetComponent<Fading> ().BeginFade(1);

		// Waiting on fading to end before restarting level
		yield return new WaitForSeconds (spawnDelay);

		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	// Function for destroying the Player and starting RespawnPlayer ();
	public static void KillPlayer (Player player) {
		Destroy (player.gameObject);
		gm.StartCoroutine(gm.RespawnPlayer ());
	}
	// Function for destroying the Skeleton
	public static void KillSkeleton (SkeletonController skeleton) {
		Destroy (skeleton.gameObject);

		WhatPlayerIsActive (0);
	}

	// Function for destroying the Brute
	public static void KillBrute (BruteController brute){
		Destroy (brute.gameObject);

		WhatPlayerIsActive (0);
	} 
	// Function for destroying the Banshee
	public static void KillBanshee (BansheeController banshee){
		Destroy (banshee.gameObject);

		WhatPlayerIsActive (0);
	} 
}

