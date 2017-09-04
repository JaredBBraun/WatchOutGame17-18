using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostKeyTrigger : MonoBehaviour {

	public bool keyVisible;
	public bool inTrigger;
	public AudioClip KeySound;


	void Start () {
		keyVisible = false;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			inTrigger = true;
		}
			
		if (other.CompareTag ("cultistGhostCore")) {
			keyVisible = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			inTrigger = false;
		}
	}

	void Update() {
		if (inTrigger) {
			if (Input.GetKeyDown(KeyCode.E)) {
				PlayerHasKey.key = true;
				AudioSource.PlayClipAtPoint(KeySound, transform.position);
				Destroy(this.gameObject);
			}
		}
	}

	void OnGUI() {
		if (inTrigger) {
			GUI.Box(new Rect(0, 60, 200, 25), "Press E to take key");
		}
	}
}
