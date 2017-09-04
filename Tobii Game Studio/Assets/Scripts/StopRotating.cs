using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRotating : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.transform.rotation.x >= 60)
        {
            this.transform.rotation = new Quaternion(60f, 60f, 0f, 0f);
        }
	}
}
