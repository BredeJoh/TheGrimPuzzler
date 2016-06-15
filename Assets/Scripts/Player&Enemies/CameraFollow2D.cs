using UnityEngine;
using System.Collections;

public class CameraFollow2D : MonoBehaviour {

// VARIABLES
	// How long the camera waits before following the players position
	float dampTime = 0.3f;
	Vector3 velocity = Vector3.zero;

	// Position of the current target
	public Transform target;

	// Variables for which player-objects are currently in the scene. Used to find their position in the scene
	public static Transform player;
	public static Transform skeleton;
	public static Transform brute;
	public static Transform banshee;
    private Transform RestrictDown;
    private Transform RestrictUp;

	// Variable for when to start the next search
	static float nextTimeToSearch = 0;
    private bool move = true;

	void Start (){
		// Finding the player
		player = GameObject.FindGameObjectWithTag ("Player").transform;
        RestrictDown = GameObject.Find("CameraRestrictDown").transform;
        RestrictUp = GameObject.Find("CameraRestrictUp").transform;

    }
	
// Update is called once per frame
	void FixedUpdate () {

		// Switching targets acording to the active player, using the public static variables from GameMaster
		if(GameMaster.activePlayer[0]){
			target = player;
		}
		if(GameMaster.activePlayer[1]){

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

		// Searching for player if there is no target
		if (target == null) {
			FindPlayer ();
			return;
		} 

		// Defining Target to follow
		if (target) {
		// Defining space that the camera will occupy in Viewport-Space
			Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
			Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
		// Following the player w/ smoothing
			Vector3 destination = transform.position + delta;
		// Function that smooths out the Vector toward the target over time
			transform.position = Vector3.SmoothDamp
				(transform.position, destination, ref velocity, dampTime);
		}


        if(gameObject.transform.position.x < RestrictDown.transform.position.x)
        {
            gameObject.transform.position = new Vector3(RestrictDown.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if(gameObject.transform.position.y < RestrictDown.transform.position.y)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, RestrictDown.transform.position.y, gameObject.transform.position.z);
        }
       if(gameObject.transform.position.x > RestrictUp.transform.position.x)
        {
            gameObject.transform.position = new Vector3(RestrictUp.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        }
       if(gameObject.transform.position.y > RestrictUp.transform.position.y)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, RestrictUp.transform.position.y, gameObject.transform.position.z);
        }
        
            
    }

	// Function for searching for any GameObject with the "Player" tag.
	void FindPlayer () {
		if (nextTimeToSearch <= Time.time) {
			GameObject searchResult = GameObject.FindGameObjectWithTag ("Player");	
			if (searchResult != null)
				player = searchResult.transform;
			nextTimeToSearch = Time.time + 0.5f;
		}
	}

	// Function for searching for any GameObject with the "skeleton" tag.
	public static void FindSkeleton () {
		if (nextTimeToSearch <= Time.time) {
			GameObject searchResult = GameObject.FindGameObjectWithTag ("skeleton");	
			if (searchResult != null)
				skeleton = searchResult.transform;
			nextTimeToSearch = Time.time + 0.5f;
		}
	}

	// Function for searching for any GameObject with the "brute" tag.
	public static void FindBrute () {
		if (nextTimeToSearch <= Time.time) {
			GameObject searchResult = GameObject.FindGameObjectWithTag ("brute");	
			if (searchResult != null)
				brute = searchResult.transform;
			nextTimeToSearch = Time.time + 0.5f;
		}
	}

	// Function for searching for any GameObject with the "banshee" tag.
	public static void FindBanshee (){
		if (nextTimeToSearch <= Time.time) {
			GameObject searchResult = GameObject.FindGameObjectWithTag ("banshee");	
			if (searchResult != null)
				banshee = searchResult.transform;
			nextTimeToSearch = Time.time + 0.5f;
		}
	}
    /*public static void FindRestrictDown()
    {
        if (nextTimeToSearch <= Time.time)
        {
            GameObject searchResult = GameObject.Find("CameraRestrictDown");
            if (searchResult != null)
                banshee = searchResult.transform;
            nextTimeToSearch = Time.time + 0.5f;
        }
    }
    public static void FindRestrictUp()
    {
        if (nextTimeToSearch <= Time.time)
        {
            GameObject searchResult = GameObject.FindGameObjectWithTag("banshee");
            if (searchResult != null)
                banshee = searchResult.transform;
            nextTimeToSearch = Time.time + 0.5f;
        }
    } 
    */
}