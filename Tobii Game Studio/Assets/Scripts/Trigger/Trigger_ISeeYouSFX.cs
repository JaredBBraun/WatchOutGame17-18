using UnityEngine;
using System.Collections;

public class Trigger_ISeeYouSFX : MonoBehaviour 
{
	public GameObject ISeeYouSFX;
	public GameObject Painting_Doll3;



	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player"))
		{
			//set the gameobject active
			ISeeYouSFX.SetActive (true);
			Painting_Doll3.SetActive (true);
			this.gameObject.SetActive (false);
		}
	}

}