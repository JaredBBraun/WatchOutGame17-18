using UnityEngine;
using System.Collections;

public class triggerr_light : MonoBehaviour
{

	public GameObject light;
    public GameObject flam;

	private void OnTriggerEnter()
	{
		light.SetActive (true);
        flam.SetActive(true);
	}

}
