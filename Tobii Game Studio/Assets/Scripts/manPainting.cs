using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manPainting : MonoBehaviour {

	public AudioClip HatMan;
	public bool HasGaze;
	public bool looking;
    bool play;
	private GazeAwareComponent _gazeAware;
	public Animator anim;


	void Start () {
		anim = GetComponent<Animator> ();
		_gazeAware = GetComponent<GazeAwareComponent> ();
        play = true;
	}

	// Update is called once per frame
	void Update () {
		if (_gazeAware.HasGaze) {
            anim.SetBool("looking", true);
            if (play) {
                PlaySnarl();
            }
        } else {
            anim.SetBool("looking", false);
        }
	}

    void PlaySnarl() {
        if (play) {
            AudioSource.PlayClipAtPoint(HatMan, transform.position);
            play = false;
        }
    }
}
