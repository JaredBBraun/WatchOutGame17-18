using UnityEngine;
using System.Collections;

public class LadderBase : MonoBehaviour {
	public LadderPlayer player;
	public GameObject ladder;
	public Transform tops;
	public Transform topt;
	public Transform bottom;

	void Start(){
		ladder=transform.parent.gameObject;
		tops=ladder.transform.Find("LadderTop").Find("LadderTopStand");
		topt=ladder.transform.Find("LadderTop").Find("LadderTopTrigger");
		bottom=transform;
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player")
		{
			Debug.Log("trigger base on");
			player.onbase=true;
			player.curLadderPos=ladder;
			player.curLadderTopS=tops;
			player.curLadderTopT=topt;
			player.curLadderBase=bottom;
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "Player")
		{
			Debug.Log("trigger base off");
			player.onbase=false;
		}
	}
}
