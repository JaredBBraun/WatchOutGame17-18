using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class displayUI : MonoBehaviour {

	public string myString;
	public Text myText;
	public float fadeTime;
	public bool displayInfo;
    private GazeAwareComponent _gazeAware;

    // Use this for initialization
    void Start () {

        if (myText != null)
        {
            myText.color = Color.clear;
        }
        else
        {
            Debug.LogWarning("[displayUI] Warning, myText is null, please set in inspector");
        }

        if(_gazeAware == null)
        {
            Debug.LogWarning("[displayUI] Warning, _gazeAware is null, please set in script or serialize field for assignment in inspector");
        }
		//Screen.showCursor = false;
		//Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		FadeText ();
        

	    if (_gazeAware != null && _gazeAware.HasGaze)
            displayInfo = true;
        else
            displayInfo = false;
    }

    /*
	void OnMouseOver()
	{
	}

	void OnMouseExit()

	{
	}
    */

	void FadeText ()
	{
        if (myText != null) //Added by AWP to prevent null reference exception
        {
            if (displayInfo)
            {
                Debug.Log("Showeing Text");
                myText.text = myString;
                myText.color = Color.Lerp(myText.color, Color.yellow, fadeTime * Time.deltaTime);

            }

            else
            {
                myText.color = Color.Lerp(myText.color, Color.clear, fadeTime * Time.deltaTime);
            }
        }

	}


}
