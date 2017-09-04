using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class noteController : MonoBehaviour {

	private bool isImgOn;
	public Image img;
	public bool byNote;

	void Start () {
		img.enabled = false;
		isImgOn = false;

	}

	void Update () {

		if (byNote) {

			if (Input.GetKeyDown ("e")) {

				if (isImgOn == true) {

					img.enabled = false;
					isImgOn = false;
				} else {
					img.enabled = true;
					isImgOn = true;
				}
			}
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			byNote = true;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			byNote = false;
		}
	}
}