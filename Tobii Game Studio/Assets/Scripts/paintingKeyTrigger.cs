using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintingKeyTrigger : MonoBehaviour {

	public bool triggerAudio;
	public bool once;
	public GameObject player;
	public AudioSource helpMe;

	void Start () {
		triggerAudio = false;
		once = true;
		player = GetComponent<GameObject> ();
		helpMe = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (triggerAudio) {
			helpMe.Play ();
		}
	}

	void OnTriggerEnter (Collider other) {
		if (once) {
			if (player) {
				triggerAudio = true;
			}
		}
	}

	void OnTriggerExit (Collider other) {
		if (player) {
			once = false;
		}
	}

	void OnTriggerStay (Collider other) {
		if (player) {
			once = false;
		}
	}
}
