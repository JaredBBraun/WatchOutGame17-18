using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintingKeyScriptMouse : MonoBehaviour {

	public bool hasMouseLook;
	public Renderer rendKey;
	public paintingKey paintingScript;

	void Start () {
		rendKey = GetComponent<Renderer> ();	//gets mesh
		rendKey.enabled = false;				//turns mesh on/off
		paintingScript = GameObject.FindGameObjectWithTag ("paintingKey").GetComponent<paintingKey> ();
		hasMouseLook = false;
	}

	// Update is called once per frame
	void Update () {
		if (paintingScript.hasMouseLook == true) {
			rendKey.enabled = true;
		}
	}
}
