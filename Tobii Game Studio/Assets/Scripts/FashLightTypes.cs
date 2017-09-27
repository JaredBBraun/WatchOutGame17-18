using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FLMODE
{
    STANDARD,
    SCAN,
    SCARE,
}


public class FashLightTypes : MonoBehaviour {
    private Light flashlight;
    public Texture scan;

    [SerializeField]
    FLMODE mode = FLMODE.STANDARD;
	// Use this for initialization
	void Start () {
        flashlight = GetComponent<Light>();
        
	}
	
	// Update is called once per frame
	void Update () {
		if (mode == FLMODE.SCAN)
        {
            flashlight.cookie = scan;
            //see things through walls at a distance
            //might be able to have a "wall hack"
        }
        else if (mode == FLMODE.STANDARD)
        {
            flashlight.cookie = null;
        }
	}
}
