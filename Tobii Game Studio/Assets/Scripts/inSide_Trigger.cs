using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inSide_Trigger : MonoBehaviour {

	public bool inSide;

	void Start () {
		inSide = false;
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			inSide = true;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			inSide = false;
		}
	}
}
