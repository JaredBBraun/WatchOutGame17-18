using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castleKey_Key : MonoBehaviour {

	public AudioClip KeySound;
	public bool inTrigger;
	public bool pickedUp;
	bool keyThere;
    public bool hasKey;

	void Start () {
		pickedUp = false;
		keyThere = true;
        hasKey = false;
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
				hasKey = true;
				pickedUp = true;
				AudioSource.PlayClipAtPoint(KeySound, transform.position);
				this.gameObject.SetActive (false);
				keyThere = false;
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
