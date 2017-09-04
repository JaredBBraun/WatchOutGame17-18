﻿using UnityEngine;
using System.Collections;

public class SceneFaderAll : MonoBehaviour {

	public static SceneFaderAll instance;

	[SerializeField]
	private GameObject fadePanel;

	[SerializeField]
	private Animator fadeAnim;


	void Awake () {
		MakeSingleton ();
	}


	void MakeSingleton () {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);

		}

	}
	public void LoadLevel (string level) {
		StartCoroutine (FadeInOut (level));
	}

	IEnumerator FadeInOut (string level){
		fadePanel.SetActive (true);

		fadeAnim.Play ("FadeIn");

		yield return StartCoroutine(MyCoroutine.WaitForRealSeconds (1f));

		Application.LoadLevel (level);

		fadeAnim.Play ("FadeOut");

		yield return StartCoroutine(MyCoroutine.WaitForRealSeconds (.7f));

		fadePanel.SetActive (false);
	}

}

