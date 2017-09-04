using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class growlTrigger : MonoBehaviour {

	public bool turnOnGrowl;
	public bool secondGrowl;
	public Trigger_Cabinet onScript;

	void Start () {
		onScript = GameObject.FindGameObjectWithTag ("secondPhase").GetComponent<Trigger_Cabinet> ();
	}
	

	void Update () {
		if (onScript.turnOnGrowl == true) {
			secondGrowl = true;
		}
	}
}
