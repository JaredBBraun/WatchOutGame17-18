using UnityEngine;
using System.Collections;

public class Trigger_AMusictoCMusic : MonoBehaviour 
{
	public GameObject A_OnTrigger1, DontDestroyOnLoad;


	public GameObject C_OnTrigger2;



	void Start()
	{
		A_OnTrigger1 = GameObject.FindGameObjectWithTag ("A_Music");
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Player")) {
			GameObject A_OnTrigger1;
			A_OnTrigger1 = GameObject.FindGameObjectWithTag ("A_Music");
		}

		{
			//set the gameobject active
			DontDestroyOnLoad.SetActive (false);
			C_OnTrigger2.SetActive (true);
		}
	}

}