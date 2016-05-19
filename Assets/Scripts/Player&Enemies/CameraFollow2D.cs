using UnityEngine;
using System.Collections;

public class CameraFollow2D : MonoBehaviour {

// VARIABLES
	float dampTime = 0.3f;
	Vector3 velocity = Vector3.zero;
	public Transform target;
	public static Transform player;
	public static Transform skeleton;
	public static Transform brute;
	public static Transform banshee;
	static float nextTimeToSearch = 0;

	void Start (){
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
// Update is called once per frame
	void FixedUpdate () {

		// Switching targets acording to the active player
		if(GameMaster.activePlayer[0]){
			target = player;
		}
		if(GameMaster.activePlayer[1]){

			//FindSkeleton();
			if (skeleton == null){
				GameMaster.activePlayer[0] = true;
				GameMaster.activePlayer[1] = false;
			}
				
				if (skeleton != null){
					target = skeleton;
				}
		}
		if(GameMaster.activePlayer[2]){

			if(brute==null){
				GameMaster.activePlayer[0] = true;
				GameMaster.activePlayer[2] = false;

				}
				if (brute != null){
					target = brute;
				}
		}
		if(GameMaster.activePlayer[3]){

			if(banshee==null){
				GameMaster.activePlayer[0] = true;
				GameMaster.activePlayer[3] = false;
			}
				if (banshee != null){
					target = banshee;
				}
		}

		// Searching for player until he spawnes
		if (target == null) {
			FindPlayer ();
			return;
		} 



		// Define Target of the follow
			if (target) {
			// Define space that camera shall occupy
				Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
				Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint
					(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			// Follow the player w. smoothing
				Vector3 destination = transform.position + delta;
				transform.position = Vector3.SmoothDamp
					(transform.position, destination, ref velocity, dampTime);
			}
	}

	void FindPlayer () {
		if (nextTimeToSearch <= Time.time) {
			GameObject searchResult = GameObject.FindGameObjectWithTag ("Player");	
			if (searchResult != null)
				player = searchResult.transform;
			nextTimeToSearch = Time.time + 0.5f;
			
		}
	}

	public static void FindSkeleton () {
		if (nextTimeToSearch <= Time.time) {
			GameObject searchResult = GameObject.FindGameObjectWithTag ("skeleton");	
			if (searchResult != null)
				skeleton = searchResult.transform;
			nextTimeToSearch = Time.time + 0.5f;
		}
	}

	public static void FindBrute () {
		if (nextTimeToSearch <= Time.time) {
			GameObject searchResult = GameObject.FindGameObjectWithTag ("brute");	
			if (searchResult != null)
				brute = searchResult.transform;
			nextTimeToSearch = Time.time + 0.5f;
		}
	}

	public static void FindBanshee (){
		if (nextTimeToSearch <= Time.time) {
			GameObject searchResult = GameObject.FindGameObjectWithTag ("banshee");	
			if (searchResult != null)
				banshee = searchResult.transform;
			nextTimeToSearch = Time.time + 0.5f;
		}
	}
}