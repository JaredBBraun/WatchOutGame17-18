using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gargoyleLowGrowl : MonoBehaviour {

	public AudioClip lowGrowl;
	public bool HasGaze;
	bool play;
	private GazeAwareComponent _gazeAware;

	void Start () {
		_gazeAware = GetComponent<GazeAwareComponent> ();
		play = true;
	}

	// Update is called once per frame
	void Update () {
		if (_gazeAware.HasGaze) {
			if (play) {
				PlayLowGrowl ();
			}
		}
	}

	void PlayLowGrowl() {
		if (play) {
			AudioSource.PlayClipAtPoint(lowGrowl, transform.position);
			play = false;
		}
	}
}
