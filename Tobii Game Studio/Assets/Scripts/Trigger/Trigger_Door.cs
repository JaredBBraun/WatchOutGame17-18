using UnityEngine;
using System.Collections;

public class Trigger_Door : MonoBehaviour 
{
	public GameObject Door10_start;

	private GameObject Door10_end;

	void Start()
	{
		Door10_end = GameObject.FindGameObjectWithTag ("Door");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player"))
		{
			//set the gameobject active
			Door10_start.SetActive (true);
			Door10_end.SetActive (false);
			this.gameObject.SetActive (false);
		}
	}

}
