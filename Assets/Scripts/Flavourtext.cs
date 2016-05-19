using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Flavourtext : MonoBehaviour {

	GameObject[] flavour;

	bool flavourIsActive = false;

	// Use this for initialization
	void Start () {
		flavour = new GameObject[4];

		//Finding skeleton flavour text
		flavour [0] = GameObject.Find ("SkeleFlav");
		flavour [1] = GameObject.Find ("BruteFlav");
		flavour [2] = GameObject.Find ("BansheeFlav");
		flavour [3] = GameObject.Find ("PlayerFlav");

		for(int i=0; i<4; i++){
			flavour [i].SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Return) && GameMaster.activePlayer[1] && !flavourIsActive){
			flavour [0].SetActive (true);
			flavourIsActive = true;
		} else if (Input.GetKeyDown(KeyCode.Return) && GameMaster.activePlayer[2] && !flavourIsActive){
			flavour [1].SetActive (true);
			flavourIsActive = true;
		} else if (Input.GetKeyDown(KeyCode.Return) && GameMaster.activePlayer[3] && !flavourIsActive){
			flavour [2].SetActive (true);
			flavourIsActive = true;
		} else if (Input.GetKeyDown(KeyCode.Return) && GameMaster.activePlayer[0] && !flavourIsActive){
			flavour [3].SetActive (true);
			flavourIsActive = true;
		} else if (Input.GetKeyDown(KeyCode.Return) && flavourIsActive){
			for (int i=0; i<4; i++){
				flavour [i].SetActive (false);
			}
			flavourIsActive = false;
		}

	}
}
