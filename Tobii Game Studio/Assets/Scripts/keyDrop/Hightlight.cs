using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hightlight : MonoBehaviour {
	public Color mouseOverHighlight;
	public Color start;
	bool mouseOver = false;

	void OnMouseEnter()
	{
		mouseOver = true;
		GetComponent<Renderer> ().material.SetColor ("_Color", mouseOverHighlight);
	}

	void OnMouseExit()
	{
		mouseOver = false;
		GetComponent<Renderer> ().material.SetColor ("_Color", start);
	}

}
