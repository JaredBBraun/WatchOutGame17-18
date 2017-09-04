//Sean Ballard
//Temporary script to keep swings from lasting forever
// 3-1-2016

using UnityEngine;
using System.Collections;

public class EndSwing : MonoBehaviour {

	//This ends the swing. I need to figure out how to end it without a separate script.

	private double swingTime;
	private double created;

	// Use this for initialization
	void Start ()
    {
		swingTime = .75;
		created = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		if ( swingTime <= Time.time - created )
		{
			Destroy(this.gameObject);
		}
	}
}
