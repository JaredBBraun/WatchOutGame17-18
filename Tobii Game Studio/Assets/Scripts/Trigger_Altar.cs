using UnityEngine;
using System.Collections;

public class Trigger_Altar : MonoBehaviour 
{
	public GameObject Flame_Altar;
	public GameObject Flame_Altar2;
	public GameObject Smoke_Altar;
	public GameObject Smoke_Altar2;
	public GameObject Smoke_Altar3;
	public GameObject Smoke_Altar4;
	public GameObject Torch_AltarOn;
	public GameObject Torch_AltarOn2;
	public GameObject Torch_AltarOff;
	public GameObject Torch_AltarOff2;
	public GameObject DustStorm;

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player"))
		{
			//set the gameobject active
			Flame_Altar.SetActive (false);
			Flame_Altar2.SetActive (false);
			Smoke_Altar.SetActive (true);
			Smoke_Altar2.SetActive (true);
			Smoke_Altar3.SetActive (true);
			Smoke_Altar4.SetActive (true);
			Torch_AltarOn.SetActive (false);
			Torch_AltarOn2.SetActive (false);
			Torch_AltarOff.SetActive (true);
			Torch_AltarOff2.SetActive (true);
			DustStorm.SetActive (true);
			this.gameObject.SetActive (false);
		}
	}

}
