using UnityEngine;
using System.Collections;

public class Trigger_DoorSlamSFX : MonoBehaviour 
{
	public GameObject DoorSlamSFX;



	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player"))
		{
			//set the gameobject active
			DoorSlamSFX.SetActive (true);
			this.gameObject.SetActive (false);
		}
	}

}