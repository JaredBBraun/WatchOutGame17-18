using UnityEngine;
using System.Collections;

public class Trigger_StatueCollapseSFX : MonoBehaviour 
{
	public GameObject StatueCollapse;



	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player"))
		{
			//set the gameobject active
			StatueCollapse.SetActive (true);
			this.gameObject.SetActive (false);
		}
	}

}