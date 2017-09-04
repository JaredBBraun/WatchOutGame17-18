using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castleKey : MonoBehaviour {

	public AudioClip KeySound;
	public bool inTrigger;
	public bool keyPickedUp;

	void Start () {
		inTrigger = false;
		keyPickedUp = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			inTrigger = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			inTrigger = false;
		}
	}

	void Update()
	{
		if (inTrigger)
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				PlayerHasKey.key = true;
				keyPickedUp = true;
				AudioSource.PlayClipAtPoint(KeySound, transform.position);
				Destroy(this.gameObject);
			}
		}
	}

	void OnGUI()
	{
		if (inTrigger)
		{
			GUI.Box(new Rect(0, 60, 200, 25), "Press E to take key");
		}
	}
}
