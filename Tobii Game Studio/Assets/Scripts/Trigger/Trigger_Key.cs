using UnityEngine;
using System.Collections;

public class Trigger_Key : MonoBehaviour 
{
	public GameObject Key3_start;

	private GameObject Key3_end;

	void Start()
	{
		Key3_end = GameObject.FindGameObjectWithTag ("Key");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player"))
		{
			//set the gameobject active
			Key3_start.SetActive (true);
			Key3_end.SetActive (false);
			this.gameObject.SetActive (false);
		}
	}

}
