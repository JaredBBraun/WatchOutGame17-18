using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class double_Door : MonoBehaviour {

	Animator anim;

	public bool playerThere;
	public bool inSide;
	public bool outSide;
   

	public playerThere_Trigger playerThereScript;
	public inSide_Trigger inSideScript;
	public outSide_Trigger outSideScript;

	public AudioClip doorOpen;
	public AudioClip doorClose;

	public bool openHasPlayed;
	public bool closedHasPlayed;
	public bool currentlyOpen;

	void Start () {
		anim = GetComponent<Animator> ();
        
//		playerThereScript = GameObject.FindGameObjectWithTag ("playerThere").GetComponent<playerThere_Trigger> ();
//		inSideScript = GameObject.FindGameObjectWithTag ("inSide").GetComponent<inSide_Trigger> ();
//		outSideScript = GameObject.FindGameObjectWithTag ("outSide").GetComponent<outSide_Trigger> ();

		currentlyOpen = false;
		openHasPlayed = false;
		closedHasPlayed = false;
	}
    void Awake()
    {
        
       // playerThereScript.playerThere = true;
       // outSideScript.outSide = true;
       // doorOut();
    }
	
	void Update () {
		if (playerThereScript.playerThere == true)
        {
			anim.SetBool ("playerThere", true);

			if (Input.GetKeyDown (KeyCode.E))
            {
				if (outSideScript.outSide == true)
                {
					doorOut ();
				}
				if (inSideScript.inSide == true)
                {
					doorIn ();
				}
			}
		}

		if (playerThereScript.playerThere == false) {
			anim.SetBool ("playerThere", false);
			anim.SetBool ("outSide", false);
			anim.SetBool ("inSide", false);
			openHasPlayed = false;

			if (currentlyOpen == true) {
				if (closedHasPlayed == false) {
					AudioSource.PlayClipAtPoint (doorClose, transform.position);
					currentlyOpen = false;
					closedHasPlayed = true;
				}
			}
		}
	}

	public void doorOut () {
		anim.SetBool ("outSide", true);
		currentlyOpen = true;

		if (openHasPlayed == false) {
			AudioSource.PlayClipAtPoint (doorOpen, transform.position);
			openHasPlayed = true;
			closedHasPlayed = false;
		}
	}

	void doorIn (){
		anim.SetBool ("inSide", true);
		currentlyOpen = true;

		if (openHasPlayed == false) {
			AudioSource.PlayClipAtPoint (doorOpen, transform.position);
			openHasPlayed = true;
			closedHasPlayed = false;
		}
	}
}
