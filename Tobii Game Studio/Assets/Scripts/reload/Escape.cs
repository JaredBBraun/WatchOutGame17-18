using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Insert))
			{
				SceneManager.LoadScene("MainMenu2");

			}
	}
}
