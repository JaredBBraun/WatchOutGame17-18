using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll_animate : MonoBehaviour {

    public string boolParamName = "lookingDoll";
	public AudioClip dollScream;
	public bool HasGaze;
	public bool lookingDoll;
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


        if (anim != null)  //Added by AWP to remove null reference
        {
            if (_gazeAware.HasGaze)
            {
                anim.SetBool(boolParamName, true);
                if (play)
                {
                    PlayAudio();
                }
            }
            else 
            {
                anim.SetBool(boolParamName, false);
            }
        }
	}

	void PlayAudio () {
		if (play) {
			AudioSource.PlayClipAtPoint(dollScream, transform.position);
			play = false;
		}
	}
}
