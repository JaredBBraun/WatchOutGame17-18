using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockDoor : MonoBehaviour {

	public bool outTrue;

	void Start () {
		outTrue = false;
	}
	
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			outTrue = true;
		}
	}

    void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            outTrue = true;
        }
    }

	void OnTriggerExit (Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			outTrue = false;
		}
	}
}
