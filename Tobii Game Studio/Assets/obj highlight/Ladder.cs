using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour
{


	private bool onLadder;
	//is this character on a ladder

	private bool onLadderTop;
	//is the character on the top of a ladder

	private bool onLadderBottom;
	//has the character hit the bottom of the ladder

	public bool usingRigidbodyFirstPersonControllerSetUp;
	//is the person using the RigidbodyFirstPersonController

	public bool usingFirstPersonControllerSetUp;
	//is the person using the RigidbodyFirstPersonController

	public float climbSpeed;
	//the speed the character move at on the ladder

	private UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController controller;
	//the RigidbodyFirstPersonController


	private UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller2;

	private float verticalInput;
	//the vertical input

	private Transform topLadderPoint;
	//the top point of this ladder

	private bool atTargetPoint;
	//tell the script if the charcter has hit the target point when they are on the top of the ladder



	public void Start ()
	{
		if (transform.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController> ()) {
			controller = transform.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController> ();
		}
		if (transform.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ()) {
			controller2 = transform.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ();
		}
	}

	public void Update ()
	{
		verticalInput = Input.GetAxis ("Vertical");
		if (onLadderTop) {
			if (!atTargetPoint) {
				MoveCharacterToPoint ();
				float ladderTopDistance;
				ladderTopDistance = Vector3.Distance (topLadderPoint.position, transform.position);
				if (ladderTopDistance < 0.2) {
					StartCoroutine ("HitTopOfLadder");
				}
			}
		}
	}


	//what to do if we are in contect we a ladder object for more than a second
	void OnTriggerStay (Collider other)
	{
		if (other.GetComponent<LadderType> ()) {
			if (verticalInput > 0.1) {
				if (other.GetComponent<LadderType> ().isLadder) {
					Vector3 fuckCSharp;
					//why is this named fuck csharp
					//let me tell unlike unityscript
					//csharp doesnt let you modify a transform's x,y or z position by iself so you have to write out this long bulshit code instead
					fuckCSharp = transform.position;
					fuckCSharp.x = other.transform.position.x;
					fuckCSharp.z = other.transform.position.z;
					transform.position = fuckCSharp;
					transform.rotation = other.transform.rotation;
					onLadder = true;
				}
			}  
			if (other.GetComponent<LadderType> ().isLadderBottom) {
				if (verticalInput < -0.1f) {
					if (onLadder) {
						StopClimbing ();
					}
				}
			}
			if (onLadder) {
				ClimbLadder ();
			}
		}
	}


	//what to do if we hit a ladder collider
	void OnTriggerEnter (Collider other)
	{
		if (other.GetComponent<LadderType> ()) {
			if (other.GetComponent<LadderType> ().isLadderTop) {
				if (usingRigidbodyFirstPersonControllerSetUp) {
					if (controller.enabled) {

					} else {
						onLadderTop = true;
						topLadderPoint = other.GetComponent<LadderType> ().topLadderEndPoint;
					}
				}
				if (usingFirstPersonControllerSetUp) {
					if (controller2.enabled) {

					} else {
						onLadderTop = true;
						topLadderPoint = other.GetComponent<LadderType> ().topLadderEndPoint;
					}
				}
			}
		}
	}

	//what to do the character is exiting the ladder to climb on top or something else
	void OnTriggerExit (Collider other)
	{
		if (other.GetComponent<LadderType> ()) {
			onLadder = false;
		}
	}


	//what to do when the character hits the top of a ladder
	IEnumerator HitTopOfLadder ()
	{
		onLadderTop = false;
		atTargetPoint = true;
		StopClimbing ();
		yield return new WaitForSeconds (0.2f);
		atTargetPoint = false;
	}

	//moves the character from one target point to the next when on coner climbpoint//use for top of ladder
	public void MoveCharacterToPoint ()
	{
		onLadder = false;
		float speed;
		speed = climbSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, topLadderPoint.position, speed);
	}


	//allows the character to climb a ladder
	public void ClimbLadder ()
	{
		if (usingRigidbodyFirstPersonControllerSetUp) {
			GetComponent<Rigidbody> ().useGravity = false;
			controller.enabled = false;
		}
		if (usingFirstPersonControllerSetUp) {
			GetComponent<Rigidbody> ().useGravity = false;
			controller2.enabled = false;
		}
		if (onLadder) {
			UseLadder ();
		}
	}


	//stops the character from climbing
	public void StopClimbing ()
	{
		if (usingRigidbodyFirstPersonControllerSetUp) {
			GetComponent<Rigidbody> ().useGravity = true;
			controller.enabled = true;
		}
		if (usingFirstPersonControllerSetUp) {
			GetComponent<Rigidbody> ().useGravity = true;
			controller2.enabled = true;
		}
		onLadder = false;

	}

	//lets the charatcer climb ladders up and down
	public void UseLadder ()
	{
		if (verticalInput > 0.1) {
			transform.Translate (Vector3.up * Time.deltaTime * climbSpeed / 7, Space.World);
		}
		if (verticalInput < -0.1f) {
			transform.Translate (Vector3.down * Time.deltaTime * climbSpeed / 7, Space.World);
		}
	}
}