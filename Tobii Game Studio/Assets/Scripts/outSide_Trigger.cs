using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outSide_Trigger : MonoBehaviour {

	public bool outSide;

	void Start () {
		outSide = false;
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			outSide = true;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			outSide = false;
		}
	}
}
