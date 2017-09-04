using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class piecePickUp : MonoBehaviour {

	private bool isImgOn;
	public Image paintPiece;
	public Image paintInventory;
	public bool byPiece;

	void Start () {
		paintPiece.enabled = false;
		paintInventory.enabled = false;
		isImgOn = false;
	}

	void Update () {

		if (byPiece) {

			if (Input.GetKeyDown ("e")) {

				if (isImgOn == true) {

					paintPiece.enabled = false;
					isImgOn = false;
				} else {
					paintPiece.enabled = true;
					paintInventory.enabled = true;
					isImgOn = true;
				}
			}
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			byPiece = true;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			byPiece = false;
		}
	}
}