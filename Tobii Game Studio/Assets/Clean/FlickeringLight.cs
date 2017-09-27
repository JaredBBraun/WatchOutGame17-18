using UnityEngine;
using System.Collections;

public class FlickeringLight : MonoBehaviour {


	Light testLight;
	public float minWaitTime;
	public float maxWaitTime;

	void Start () {
		testLight = GetComponent<Light>();
		StartCoroutine(Flashing());
	}

	IEnumerator Flashing ()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(minWaitTime,maxWaitTime));
			testLight.enabled = ! testLight.enabled;

		}
	}
}