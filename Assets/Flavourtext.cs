using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Flavourtext : MonoBehaviour {

	GameObject[] flavour;

	bool flavourIsActive = false;

	// Use this for initialization
	void Start () {
		flavour = new GameObject[3];

		//Finding skeleton flavour text
		flavour [0] = GameObject.Find ("SkeleFlav");
		flavour [1] = GameObject.Find ("BruteFlav");
		flavour [2] = GameObject.Find ("BansheeFlav");
		flavour [0].SetActive (false);
		flavour [1].SetActive (false);
		flavour [2].SetActive (false);
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Return) && GameMaster.currentPlayerSkeleton && !flavourIsActive){
			flavour [0].SetActive (true);
			flavourIsActive = true;
		} else if (Input.GetKeyDown(KeyCode.Return) && GameMaster.currentPlayerBrute && !flavourIsActive){
			flavour [1].SetActive (true);
			flavourIsActive = true;
		} else if (Input.GetKeyDown(KeyCode.Return) && GameMaster.currentPlayerBanshee && !flavourIsActive){
			flavour [2].SetActive (true);
			flavourIsActive = true;
		}else if (Input.GetKeyDown(KeyCode.Return) && flavourIsActive){
			for (int i=0; i<3; i++){
				flavour [i].SetActive (false);
			}
			flavourIsActive = false;
		}

	}
}
