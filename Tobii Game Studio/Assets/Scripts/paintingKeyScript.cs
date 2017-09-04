using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintingKeyScript : MonoBehaviour {

	public bool hasGaze;
	public Renderer rendKey;
	public paintingKey paintingScript;

	void Start () {
		rendKey = GetComponent<Renderer> ();	//gets mesh
		rendKey.enabled = false;				//turns mesh on/off
		paintingScript = GameObject.FindGameObjectWithTag ("keyPainting").GetComponent<paintingKey> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (paintingScript.hasGaze == true) {
			rendKey.enabled = true;
		}
	}
}
