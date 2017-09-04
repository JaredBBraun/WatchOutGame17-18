using UnityEngine;
using System.Collections;

public class Trigger_Cabinet : MonoBehaviour 
{
	public GameObject cabinet_start;
	public GameObject Destruction;
	public GameObject Creature_Pit;
	public GameObject SkeletonBody_NoHead;
	public GameObject Trigger_4;
	public GameObject Door_start;
	public GameObject Door_Block;
	public GameObject skull;
	public GameObject FirePitSFX;

	public bool turnOnGrowl;

	private GameObject cabinet_end;

	void Start()
	{
		cabinet_end = GameObject.FindGameObjectWithTag ("Cabinet");
		turnOnGrowl = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player"))
		{
			//set the gameobject active
			cabinet_start.SetActive (true);
			cabinet_end.SetActive (false);
			Destruction.SetActive (true);
			Creature_Pit.SetActive (false);
			SkeletonBody_NoHead.SetActive (true);
			Trigger_4.SetActive (true);
			Door_start.SetActive (false);
			Door_Block.SetActive (true);
			skull.SetActive (true);
			FirePitSFX.SetActive (true);
			this.gameObject.SetActive (false);

			turnOnGrowl = true;
		}
	}

}