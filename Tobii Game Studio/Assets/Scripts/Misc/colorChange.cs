using UnityEngine;
using System.Collections;
//got from a dude online
public class colorChange : MonoBehaviour {

	float timeLeft;
	Color targetColor;
    private GazeAwareComponent _gazeAware;


	// Use this for initialization
	void Start () {
        _gazeAware = GetComponent<GazeAwareComponent>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (_gazeAware.HasGaze)
        {
            if (timeLeft <= Time.deltaTime)
            {
                // transition complete
                // assign the target color
                GetComponent<Renderer>().material.color = targetColor;

                // start a new transition
                targetColor = new Color(Random.value, Random.value, Random.value);
                timeLeft = 1.0f;
            }
            else
            {
                // transition in progress
                // calculate interpolated color
                GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, targetColor, Time.deltaTime / timeLeft);

                // update the timer
                timeLeft -= Time.deltaTime;
            }
        }
	}
}
