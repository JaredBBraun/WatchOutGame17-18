using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintingKey : MonoBehaviour {

	public GazeAwareComponent _gazeAware;
	public Animation anim;				//animation
	public bool hasGaze;				//turn off and on mesh
	public bool hasMouseLook;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation> (); 		//gets animation
		hasGaze = false;						//bool for turning off and on mesh

	}

	// Update is called once per frame
	void Update () {
		if (_gazeAware.HasGaze) {
			anim.Play ();
			hasGaze = true;						//makes it so mesh can turn on
			hasMouseLook = true;
				
		} else 
			anim.Stop ();
		}
}