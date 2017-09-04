using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isActiveScript_2 : MonoBehaviour {

	public bool isActive;
	public GameObject Player;

	void Start () {
		isActive = false;
		Player = GetComponent<GameObject> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			isActive = true;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			isActive = false;
		}
	}
}
