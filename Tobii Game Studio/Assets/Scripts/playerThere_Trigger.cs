using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerThere_Trigger : MonoBehaviour {

	public bool playerThere;

	void Start () {
		playerThere = false;
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			playerThere = true;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			playerThere = false;
		}
	}
}
