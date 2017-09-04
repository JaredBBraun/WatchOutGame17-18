using UnityEngine;
using System.Collections;

public class Trigger_EndOfDemo : MonoBehaviour 
{

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player"))
		{
			//set the gameobject active
			Debug.Log("Level Has Ended.");
			UnityEngine.SceneManagement.SceneManager.LoadScene ("End_Credit");
		}
	}

}