using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCultistGhostKey : MonoBehaviour {

	public bool keyVisible;

	void Start () {
		keyVisible = false;
	}
	

	void Update () {

	}

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("cultistGhostCore")) {
			keyVisible = true;
		}
	}
}
