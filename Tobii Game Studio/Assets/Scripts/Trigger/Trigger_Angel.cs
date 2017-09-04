using UnityEngine;
using System.Collections;

public class Trigger_Angel : MonoBehaviour 
{
	public GameObject Monument_Angel_Start;

	private GameObject Monument_Angel_Destroyed_End;

	void Start()
	{
		Monument_Angel_Destroyed_End = GameObject.FindGameObjectWithTag ("Angel");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player"))
		{
			//set the gameobject active
			Monument_Angel_Start.SetActive (true);
			Monument_Angel_Destroyed_End.SetActive (false);
			this.gameObject.SetActive (false);
		}
	}

}