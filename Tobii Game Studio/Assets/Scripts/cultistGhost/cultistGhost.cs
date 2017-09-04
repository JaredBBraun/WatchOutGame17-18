using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cultistGhost : MonoBehaviour {

	Animator anim;									//var for getting animation
	public bool move;								//trigger var for ghost animation, same in cultistGhostTrigger script
	public cultistGhostTrigger ghostTriggerScript;		//creates empty var to "store" cultistGhostTrigger script in so this script can access the change in "move"
	public AudioClip ghostScream;
	bool play;

	void Start () {
		anim = GetComponent<Animator> ();																					//sets blank spot in inspector for animation to be assigned
		ghostTriggerScript = GameObject.FindGameObjectWithTag ("cultistGhostTrigger").GetComponent<cultistGhostTrigger> ();		//sets the empty var to contain information from the cultistGhostTrigger script
		play = true;
	}
	

	void Update () {
		if (ghostTriggerScript.move == true) {			//checks to see if move is true from cultistGhostTrigger
			anim.SetBool ("move", true);			//sets the animator bool for the cultistGhost animation to true so it will run
			if (play) {
				PlayAudio ();
			}
		}
	}

	void PlayAudio () {
		AudioSource.PlayClipAtPoint (ghostScream, transform.position);
		play = false;
	}
		
}
