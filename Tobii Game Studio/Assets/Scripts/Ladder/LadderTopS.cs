using UnityEngine;
using System.Collections;

public class LadderTopS : MonoBehaviour {
	public LadderPlayer player;
	public GameObject ladder;
	public Transform tops;
	public Transform topt;
	public Transform bottom;

	void Start(){
		ladder=transform.parent.gameObject.transform.parent.gameObject;
		tops=transform.parent.Find("LadderTopStand");
		topt=transform;
		bottom=ladder.transform.Find("LadderBase");
	}
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player")
		{
			Debug.Log("trigger top on");
			player.ontop=true;
			player.curLadderPos=ladder;
			player.curLadderTopS=tops;
			player.curLadderTopT=topt;
			player.curLadderBase=bottom;
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "Player")
		{
			Debug.Log("trigger top off");
			player.ontop=false;
		}
	}
}
