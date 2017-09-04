using UnityEngine;
using System.Collections;

public class Cultist_Gaze : MonoBehaviour 
{
	public GameObject Explosion;
	public GameObject cultistsmol;

	private GazeAwareComponent _gazeAware;

	// Use this for initialization
	void Start () {
		_gazeAware = GetComponent<GazeAwareComponent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_gazeAware.HasGaze) {
			Debug.Log ("has been peeped at");
			Explosion.SetActive (true);
			Object.Destroy (cultistsmol.gameObject, 1.0f);
		}
	}
}
		