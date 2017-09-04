using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDoor : MonoBehaviour
{
    public DoorScript mydoor;
   

	// Use this for initialization
	void Start ()
    {
        mydoor.open = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
