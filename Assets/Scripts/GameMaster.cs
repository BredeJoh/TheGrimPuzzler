using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

	public static GameMaster gm;

	public static bool currentPlayer = true;
	public static bool currentPlayerSkeleton = false;
	public static bool currentPlayerBrute = false;
	public static bool currentPlayerBanshee = false;

	public static int collectables;
	Text collect;

	int spawnDelay = 1;

	public Transform playerPrefab;
	public Transform spawnPoint;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster>();
		collect = GameObject.Find ("CurrentCollectables").GetComponent<Text> ();
	}

	void FixedUpdate(){
		collect.text = ("Collected:" + collectables);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q) && !currentPlayerSkeleton) {
			// Focus on Skeleton
			currentPlayerSkeleton = true;
			currentPlayer = false;
			currentPlayerBrute = false;
			currentPlayerBanshee = false;
		} else if (Input.GetKeyDown (KeyCode.Q) && currentPlayerSkeleton) {
			// Focus on Player
			currentPlayerSkeleton = false;
			currentPlayerBrute = false;
			currentPlayer = true;
			currentPlayerBanshee = false;
		}
		if (Input.GetKeyDown (KeyCode.W) && !currentPlayerBrute) {
			// Focus on Brute
			currentPlayerSkeleton = false;
			currentPlayerBrute = true;
			currentPlayer = false;
			currentPlayerBanshee = false;
		} else if (Input.GetKeyDown (KeyCode.W) && currentPlayerBrute) {
			// Fucus on Player
			currentPlayerSkeleton = false;
			currentPlayerBrute = false;
			currentPlayer = true;
			currentPlayerBanshee = false;
		}
		if (Input.GetKeyDown (KeyCode.E) && !currentPlayerBanshee) {
			// Focus on Brute
			currentPlayerSkeleton = false;
			currentPlayerBrute = false;
			currentPlayer = false;
			currentPlayerBanshee = true;
		} else if (Input.GetKeyDown (KeyCode.E) && currentPlayerBanshee) {
			// Fucus on Player
			currentPlayerSkeleton = false;
			currentPlayerBrute = false;
			currentPlayer = true;
			currentPlayerBanshee = false;
		}
	}

	public IEnumerator RespawnPlayer () {

		yield return new WaitForSeconds (spawnDelay);
		
		Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
	}

	public static void KillPlayer (Player player) {
		Destroy (player.gameObject);
		gm.StartCoroutine(gm.RespawnPlayer ());
	}
	public static void KillSkeleton (SkeletonController skeleton) {
		Destroy (skeleton.gameObject);
		GameMaster.currentPlayer = true;
		GameMaster.currentPlayerSkeleton = false;
	}
	public static void KillBrute (BruteController brute){
		Destroy (brute.gameObject);
		GameMaster.currentPlayer = true;
		GameMaster.currentPlayerBrute = false;
	} 
}

