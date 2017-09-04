using UnityEngine;
using System.Collections;

public class Trigger_Skeleton : MonoBehaviour 
{
	public GameObject Explosion;
	public GameObject cultistsmol;


	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player")) {
			//set the gameobject active
			Explosion.SetActive (true);
			Object.Destroy(cultistsmol.gameObject, 1.0f);
			this.gameObject.SetActive (false);
		}
	}
}