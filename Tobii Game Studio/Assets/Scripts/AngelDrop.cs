using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelDrop : MonoBehaviour {

	private bool playTriggerAnimation = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playTriggerAnimation) {
			GetComponent<Animation>().Play ("Angel3");
		}
	}

	public void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "Player") {
			playTriggerAnimation = true;

		}
	}

}
