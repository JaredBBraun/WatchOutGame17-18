using UnityEngine;
using System.Collections;

public class Trigger_WaltztoAMusic : MonoBehaviour 
{
	public GameObject Waltz_OnPlay;
	public GameObject A_OnTrigger1;


	void Start()
	{
		Waltz_OnPlay = GameObject.FindGameObjectWithTag ("Waltz_Music");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player"))
		{
			//set the gameobject active
			Waltz_OnPlay.SetActive (false);
			A_OnTrigger1.SetActive (true);
			this.gameObject.SetActive (false);
		}
	}

}