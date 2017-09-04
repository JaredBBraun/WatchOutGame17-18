using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gargoyleSnarl : MonoBehaviour {

	public AudioClip snarl;
	public AudioClip nothing;
	public bool HasGaze;
	public bool secondGrowl;
	public growlTrigger triggerScript;
	bool play;
	private GazeAwareComponent _gazeAware;

	void Start () {
		_gazeAware = GetComponent<GazeAwareComponent> ();
		play = true;
		triggerScript = GameObject.FindGameObjectWithTag ("growlTrigger").GetComponent<growlTrigger> ();
	}

	// Update is called once per frame
	void Update () {
		if (triggerScript.secondGrowl == true) {
			if (_gazeAware.HasGaze) {
				if (play) {
					PlaySnarl ();
				}
			} 
		}
	}

	void PlaySnarl() {
		if (play) {
			AudioSource.PlayClipAtPoint(snarl, transform.position);
			play = false;
		}
	}

	void PlayNothing () {
		AudioSource.PlayClipAtPoint (nothing, transform.position);
	}
}
