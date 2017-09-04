using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyVisibility : MonoBehaviour {

	public bool keyVisible;
	public bool turnLightOn;
	public ghostKeyTrigger keyCollider;
	public MeshRenderer rend;

	void Start () {
		keyCollider = GameObject.FindGameObjectWithTag ("keyCollider").GetComponent<ghostKeyTrigger> ();
		rend = GetComponent<MeshRenderer> ();
		rend.enabled = (false);
 	}

	void Update () {
		if (keyCollider.keyVisible == true) {
			rend.enabled = (true);
			turnLightOn = true;
		}
	}
}
