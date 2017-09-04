using UnityEngine;
using System.Collections;

public class Trigger_Glass : MonoBehaviour 
{
	public GameObject Glass_start;

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player"))
		{
			//set the gameobject active
			Glass_start.SetActive (false);
			this.gameObject.SetActive (false);
		}
	}

}
