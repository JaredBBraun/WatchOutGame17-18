using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGoneScript : MonoBehaviour {

	public bool playerGone;

	void Start () {
		playerGone = true;
	}
	
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			playerGone = false;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			playerGone = true;
		}
	}
}
