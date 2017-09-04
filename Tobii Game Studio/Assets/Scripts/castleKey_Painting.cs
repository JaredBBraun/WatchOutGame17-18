using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castleKey_Painting : MonoBehaviour {

	Animator anim;
	public AudioClip thunder;
	public bool pickedUp;
	public castleKey_Key keyScript;

	void Start () {
		anim = GetComponent<Animator> ();
		keyScript = GameObject.FindGameObjectWithTag ("castleKey").GetComponent<castleKey_Key> ();
	}

	void Update () {
		if (keyScript.pickedUp == true) {
            if (!anim.GetBool("pickedUp")) {
     //			anim.SetBool ("pickedUp", true);
                AudioSource.PlayClipAtPoint(thunder, transform.position, 2.0f);
                anim.SetBool("pickedUp", true);
            }
        }
	}

}
