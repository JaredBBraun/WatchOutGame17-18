using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleToggle : MonoBehaviour {

	public GameObject ParticleEmitter;
	public GameObject ParticleEmitter2;
	public bool isTouched;
	public bool isTouched2;


	// Use this for initialization
	void Start () {
		ParticleEmitter.SetActive (false);
		ParticleEmitter2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (isTouched) {
			ParticleEmitter.SetActive (true);

		}
		if (isTouched2) {
			ParticleEmitter2.SetActive (true);
		}
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("TheWall")) {
			isTouched = true;

		}
		if (other.gameObject.CompareTag ("TheWall2")) {
			isTouched2 = true;

		}

	}
}
