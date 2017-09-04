using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuController1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartScene1()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Pax_level1");
	}

	public void QuitTheGame()
	{

		Application.Quit ();
	}




}
