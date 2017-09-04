using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorAnimController : MonoBehaviour {

	Animator anim;

	public AudioClip doorOpen;
	public AudioClip doorClose;

	public bool inTrue;
	public bool outTrue;
//	public bool playerGone;
    public bool hasKey;

	public GameObject key;

//	public playerGoneScript goneScript;
	public unlockDoor outScript;
	public unlockDoorIn inScript;
    public castleKey_Key hasCastleKey;

	void Start () {
		anim = GetComponent<Animator> ();
//		key = GetComponent<GameObject> ();
//		goneScript = GameObject.FindGameObjectWithTag ("goneTrigger").GetComponent<playerGoneScript> ();
		outScript = GameObject.FindGameObjectWithTag ("outTrigger").GetComponent<unlockDoor> ();
		inScript = GameObject.FindGameObjectWithTag ("inTrigger").GetComponent<unlockDoorIn> ();
        hasCastleKey = GameObject.FindGameObjectWithTag("castleKey").GetComponent<castleKey_Key>();
	}
	

	void Update () {
//		if (goneScript.playerGone == false) {
//			anim.SetBool ("playerGone", false);
			if (hasCastleKey.hasKey == true) {
				if (Input.GetKeyDown (KeyCode.E)) {
					if (outScript.outTrue == true) {
						DoorOutOpen ();
					}
					if (inScript.inTrue == true) {
						DoorInOpen ();
					}
				}
//			}
		}

//		if (goneScript.playerGone == true) {
//			anim.SetBool ("playerGone", true);
			if (outScript.outTrue == false) {
				DoorOutClose ();
			}
			if (inScript.inTrue == false) {
				DoorInClose ();
			}
			
//		}
	}

	void DoorOutOpen () {
		anim.SetBool ("outTrue", true);
		AudioSource.PlayClipAtPoint (doorOpen, transform.position);
		PlayerHasKey.key = false;
	}

	void DoorOutClose () {
		anim.SetBool ("outTrue", false);
		AudioSource.PlayClipAtPoint (doorClose, transform.position);
		PlayerHasKey.key = false;
	}

	void DoorInOpen () {
		anim.SetBool ("inTrue", true);
		AudioSource.PlayClipAtPoint (doorOpen, transform.position);
	}

	void DoorInClose () {
		anim.SetBool ("inTrue", false);
		AudioSource.PlayClipAtPoint (doorClose, transform.position);
	}
}
