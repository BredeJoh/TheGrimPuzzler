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
		flavour[0] = GameObject.Find ("SkeleFlav");
		flavour[0].SetActive (false);
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Return) && GameMaster.currentPlayerSkeleton && !flavourIsActive){
			flavour[0].SetActive (true);
			flavourIsActive = true;
		} else if (Input.GetKeyDown(KeyCode.Return) && flavourIsActive){
			flavour[0].SetActive (false);
			flavourIsActive = false;
		}

	}
}
