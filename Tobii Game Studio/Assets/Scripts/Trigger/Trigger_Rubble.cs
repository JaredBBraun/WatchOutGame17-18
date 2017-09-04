using UnityEngine;
using System.Collections;

public class Trigger_Rubble : MonoBehaviour 
{
	public GameObject Rubble1;

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player"))
		{
			//set the gameobject active
			Rubble1.SetActive (true);
			this.gameObject.SetActive (false);
		}
	}

}
