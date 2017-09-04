using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSays : MonoBehaviour {
    /// <summary>
    /// Want to show user, the order of what cube to look at
    /// kill user if: look at cube before simon says, look at worng cube
    /// </summary>
    public GameObject Cube1;
    public GameObject Cube2;
    Renderer rend1;
    Renderer rend2;
    bool ableToLook;
    public Text WinText;

    private GazeAwareComponent _gazeAware;

    // Use this for initialization
    void Start () {
        WinText.enabled = false;

        _gazeAware = GetComponent<GazeAwareComponent>();

        rend1 = Cube1.GetComponent<Renderer>();
        rend1.enabled = true;

        rend2 = Cube2.GetComponent<Renderer>();
        rend2.enabled = true;

        rend1.material.color = Color.black;
    }
	
	// Update is called once per frame
	void Update () {
        if (_gazeAware.HasGaze == true && ableToLook == false)
        {

            Application.LoadLevel(Application.loadedLevel);
        }
        else if (_gazeAware.HasGaze == true && ableToLook == true)
        {
            WinText.enabled = true;
        }



        StartCoroutine("Wait");
        
    }

    IEnumerator Wait()
    {
      yield return new WaitForSeconds(2f);
        rend1.material.color = Color.white;
        rend2.material.color = Color.black;
        ableToLook = true;

        
    }
}
