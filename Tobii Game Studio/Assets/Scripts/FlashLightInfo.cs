using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLightInfo : MonoBehaviour {

	public Text FlashLightText;
	private bool Enactive = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!Enactive) {
			FlashLightText.gameObject.SetActive (false);
		}
			
	}


	void OnTriggerEnter (Collider other){
		if ((other.gameObject.tag == "MainCamera") && (Input.GetKeyDown (KeyCode.E))) {
			Enactive = false;
		}
	}
}
