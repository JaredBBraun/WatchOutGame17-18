using UnityEngine;
using System.Collections;

public class LadderPlayer : MonoBehaviour {

	public bool ontop;
	public bool onbase;
	public bool onladder;
	public CharacterController mychar;
	public GameObject curLadderPos;
	public Transform curLadderTopS;
	public Transform curLadderTopT;
	public Transform curLadderBase;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (onbase && Input.GetKey("e") && !onladder)
		{
			onladder=true;
			mychar.enabled=false;
			transform.position = new Vector3 (curLadderBase.position.x, transform.position.y,curLadderBase.position.z);

		}
		else if (ontop && Input.GetKey("e") && !onladder)
		{
			onladder=true;
			mychar.enabled=false;
			transform.position = new Vector3 (curLadderTopT.position.x, transform.position.y,curLadderTopT.position.z);
			Debug.Log("put you on the ladder from the top to pos: "+curLadderTopT.position);
		}
		else if (onladder && Input.GetKey("w"))
		{
			//move player up, max height of ladder
			moveUpLadder();
		}
		else if (onladder && Input.GetKey("s"))
		{
			//move player up, max height of ladder
			moveDownLadder();
		}
		else if (onladder && Input.GetKey("e") && onbase)
		{
			onladder=false;
			mychar.enabled=true;
		}
		else if (onladder && Input.GetKey("e") && ontop)
		{
			onladder=false;
			mychar.enabled=true;
			ontop=false;
			//move player to top stand pos
			transform.position = new Vector3 (curLadderTopS.position.x, transform.position.y,transform.position.z);
		}

	}

	void moveUpLadder(){
		float boxY=mychar.GetComponent<BoxCollider>().center.y;
		if(mychar.transform.position.y+boxY <= curLadderTopT.position.y)
		{
			mychar.transform.position += Vector3.up / 30;
		} else
			Debug.Log("cannot move any further upward");
	}

	void moveDownLadder(){
		if (!onbase)
		mychar.transform.position += (-Vector3.up / 30);
		else 
			Debug.Log("cannot move any further downward");
	}

}
