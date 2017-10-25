using UnityEngine;
using System.Collections;

public class LadderType : MonoBehaviour
{

	public bool isLadder;
	//is this the ladder for to go up and down

	public bool isLadderTop;
	//is this the top of the ladder

	public bool isLadderBottom;
	//is this the bottom of the ladder

	public Transform topLadderEndPoint;
	//if this is the top of the ladder it need an end point to move the chracter to


	//lets the player know if the if script needs a topLadderEndPoint
	public void Start ()
	{
		if (isLadderTop) {
			if (topLadderEndPoint == null) {
				Debug.LogError ("A ladder object is marks as isLadderTop but has no topLadderEndPoint. The ladder top needs a topLadderEndPoint to work properly");
			}
		}

	}


}