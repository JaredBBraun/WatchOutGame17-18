using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castleAnimationController : MonoBehaviour {

	public bool HasGaze;
	public bool looking;
	private GazeAwareComponent _gazeAware;
	public Animator anim;
	public castleKey castleKeyScript;

	void Start () {
		anim = GetComponent<Animator> ();
		_gazeAware = GetComponent<GazeAwareComponent> ();
	}

	// Update is called once per frame
	void Update () {
		if (_gazeAware.HasGaze) {
			anim.SetBool ("looking", true);
		} else
			anim.SetBool ("looking", false);
	}
}
