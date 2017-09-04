// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

public class FalshlightCs : MonoBehaviour {
	//Script made by StrupsGames

	//[SerializeField] private MouseLook m_MouseLook;


	public Light flashlight;
	public GameObject soundOn;
	public GameObject soundOff;
	private bool flicker;


	void  Start (){
		flashlight.enabled = true; 

	}


	void  Update (){ 
		if(Input.GetKeyDown(KeyCode.F)) // You can choose any button, im using the button F, rename it if you want a diffrent button to use.
		{
			if(flashlight.enabled == false)
			{
				flicker = true;
				flashlight.enabled = true;
				//soundOn.GetComponent.<AudioSource>().Play();
			}
			else
			{
				flicker = false;
				flashlight.enabled = false;
				//soundOff.GetComponent.<AudioSource>().Play();
			}
		}






		if (flicker == true)
		{
			if ( Random.value < .05 )//a random chance
			{
				if (flashlight.enabled == true ) //if the light is on...
				{
					flashlight.intensity = 0.9f; //turn it off
				}
				else
				{
					flashlight.intensity = 3.87f; //turn it on
				}
			}
		}
	}









}