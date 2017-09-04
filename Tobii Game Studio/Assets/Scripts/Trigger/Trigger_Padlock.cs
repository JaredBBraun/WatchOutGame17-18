using UnityEngine;
using System.Collections;

public class Trigger_Padlock : MonoBehaviour 
{
	public GameObject Padlock_start;

	private GameObject Padlock_end;

	void Start()
	{
		Padlock_end = GameObject.FindGameObjectWithTag ("Padlock");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player"))
		{
			//set the gameobject active
			Padlock_start.SetActive (true);
			Padlock_end.SetActive (false);
			this.gameObject.SetActive (false);
		}
	}

}
