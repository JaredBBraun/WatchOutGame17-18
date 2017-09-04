using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noKeyDoorAnimController : MonoBehaviour {

	Animator anim;

	public AudioClip doorOpenNo;
	public AudioClip doorCloseNo;

	public bool inTrue;
	public bool outTrue;
	public bool playerGone;

//	public playerGoneScript goneScriptNo;
	public unlockDoor outScriptNo;
	public unlockDoorIn inScriptNo;

	void Start () {
		anim = GetComponent<Animator> ();
//		goneScriptNo = GameObject.FindGameObjectWithTag ("goneTriggerNo").GetComponent<playerGoneScript> ();
		outScriptNo = GameObject.FindGameObjectWithTag ("outTriggerNo").GetComponent<unlockDoor> ();
		inScriptNo = GameObject.FindGameObjectWithTag ("inTriggerNo").GetComponent<unlockDoorIn> ();
	}


	void Update () {
//		if (goneScriptNo.playerGone == false) {
//			anim.SetBool ("playerGone", false);
			if (Input.GetKeyDown (KeyCode.E)) {
				if (outScriptNo.outTrue == true) {
					DoorOutOpen ();
				}
				if (inScriptNo.inTrue == true) {
					DoorInOpen ();
				}
			}
//		}

//		if (goneScriptNo.playerGone == true) {
//			anim.SetBool ("playerGone", true);
			if (outScriptNo.outTrue == false) {
				DoorOutClose ();
			}
			if (inScriptNo.inTrue == false) {
				DoorInClose ();
			}
		}
//	}

	void DoorOutOpen () {
		anim.SetBool ("outTrue", true);
		AudioSource.PlayClipAtPoint (doorOpenNo, transform.position);
	}

	void DoorOutClose () {
		anim.SetBool ("outTrue", false);
		AudioSource.PlayClipAtPoint (doorCloseNo, transform.position);
	}

	void DoorInOpen () {
		anim.SetBool ("inTrue", true);
		AudioSource.PlayClipAtPoint (doorOpenNo, transform.position);
	}

	void DoorInClose () {
		anim.SetBool ("inTrue", false);
		AudioSource.PlayClipAtPoint (doorCloseNo, transform.position);
	}
}