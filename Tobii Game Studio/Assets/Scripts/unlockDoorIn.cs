using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockDoorIn : MonoBehaviour {

	public bool inTrue;

	void Start () {
		inTrue = false;
	}
	
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			inTrue = true;
		}
	}

    void OnTriggerStay (Collider other) {
        if (other.gameObject.CompareTag ("Player")) {
            inTrue = true;
        }
    }

	void OnTriggerExit (Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			inTrue = false;
		}
	}
}
