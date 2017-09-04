using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintingKeyMouse : MonoBehaviour {

	public Animation anim;				//animation
	public bool hasMouseLook;				//turn off and on mesh
	public GameObject player;
	bool didRayHit;
	Ray ray;
	RaycastHit hitInfo;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation> (); 		//gets animation
		hasMouseLook = false;						//bool for turning off and on mesh
		player = GetComponent<GameObject> ();
		ray = new Ray (transform.position, transform.forward);
		didRayHit = Physics.Raycast (ray, out hitInfo, 10f);
		didRayHit = false;
	}

	// Update is called once per frame
	void Update () {
		if (didRayHit) {
			hasMouseLook = true;
		}

		if (hasMouseLook) {
			anim.Play ();
		} else 
			anim.Stop ();
	}
}