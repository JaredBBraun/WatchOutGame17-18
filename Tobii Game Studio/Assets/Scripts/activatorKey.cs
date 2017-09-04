using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activatorKey : MonoBehaviour {

	public AudioClip KeySound; 
	public bool active;				//var for activating cultistGhostTrigger
	public bool inTrigger;

	void Start () {
		active = false;				//sets active to false at start
	}

	void Update () {
		if (inTrigger) {
			if (Input.GetKeyDown(KeyCode.E)) {
				PlayerHasKey.key = true;
				AudioSource.PlayClipAtPoint(KeySound, transform.position);
				active = true;				//sets active to true
				Destroy(this.gameObject);
			}
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			inTrigger = true;
		}
	}

	void OnTriggerExit( Collider other) {
		if (other.gameObject.CompareTag("Player"))
			inTrigger = false;
	}

	void OnGUI() {
		if (inTrigger) {
			GUI.Box(new Rect(0, 60, 200, 25), "Press E to take key");
		}
	}
}
