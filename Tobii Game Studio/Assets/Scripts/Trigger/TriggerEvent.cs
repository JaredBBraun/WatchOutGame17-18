using UnityEngine;
using System.Collections;

public class TriggerEvent : MonoBehaviour 
{
	public GameObject cubeObject;

	private GameObject cubeObject2;

	void Start()
	{
		cubeObject2 = GameObject.FindGameObjectWithTag ("Cube");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player"))
		{
			//set the gameobject active
			cubeObject.SetActive(true);
			cubeObject2.SetActive (false);
			this.gameObject.SetActive (false);
		}
	}
		
}
