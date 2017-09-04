using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cultistGhostTrigger : MonoBehaviour {

	public bool move;						//trigger var for ghost animation
//	public bool active; 					//var for activating collider

	bool triggered;							//var to turn off collider on exit

	public GameObject player;				//empty var to assign player
//	public activatorKey activatorScript;	//creates empty var to "store" activatorKey script in so this script can access information

	void Start () {
		player = GetComponent<GameObject> ();		//sets empty slot in inspecter for player to be assigned
		triggered = true;							//sets the triggered state to true at start
		move = false;								//sets the move state to be false at start
//		active = false;								//sets active to false at start
//		activatorScript = GameObject.FindGameObjectWithTag ("activatorKey").GetComponent<activatorKey> ();	//sets the empty var to contain information from the keyActivator script
	}
	

	void Update () {
//		if (activatorScript.active == true) {		//checks to see if active is true in activatorScript
//			active = true;							//sets active to true here
//		}
	}

	void OnTriggerEnter (Collider other) {
	//	if (active) {								//checks to see if active is true here
			if (other.CompareTag ("Player")) {		//checks to see if player has hit the collider
				if (triggered) {					//checks to see if triggered is still true
					move = true;					//sets move to true
				}
			}
	//	}
	}

	void OnTriggerExit (Collider other) {
		if (other.CompareTag ("Player")) {		//checks to see if player has exited the collider
			triggered = false;					//turns collider off on exit
		}
	}

}