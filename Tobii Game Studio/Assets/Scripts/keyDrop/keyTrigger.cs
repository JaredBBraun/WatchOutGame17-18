using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyTrigger : MonoBehaviour {

	public bool keyVisible;
	public bool ghostPass;
	public ghostKeyTrigger keyTriggerScript;

	void Start () {
		keyVisible = false;
		keyTriggerScript = GameObject.FindGameObjectWithTag ("keyTrigger").GetComponent<ghostKeyTrigger> ();
		
	}
	
	void Update () {
		if (keyTriggerScript.keyVisible == true) {
			keyVisible = true;
		}
	}
}

