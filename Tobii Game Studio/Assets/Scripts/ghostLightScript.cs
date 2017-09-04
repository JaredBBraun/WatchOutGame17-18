using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostLightScript : MonoBehaviour {

	public Light keyLight;
	public bool lightOn;
    public bool turnLightOn;
	public keyVisibility keyScript;
    

	void Start () {
		keyLight.enabled = lightOn;
		lightOn = (false);
		keyScript = GameObject.FindGameObjectWithTag ("cultistKey").GetComponent<keyVisibility> ();
	}
	
	void Update () {
		if (keyScript.turnLightOn == true) {
			lightOn = (true);
		}		
	}
}
