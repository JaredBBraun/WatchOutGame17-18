using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using Tobii.EyeX.Framework;

public class StatueSays : MonoBehaviour
{
    bool isInside;
    bool isLocked;
    private FirstPersonController2 mychar;
    public GameObject Player;
    private MouseLook ml;
    public CharacterMotor cm;
    private Rigidbody rb;
    private GazeAwareComponent Gaze;
    public GazePointDataComponent _gazePointDataComponent;
    EyeXHost eyeXHost;
    

    // Use this for initialization
    void Start()
    {
        mychar = Player.GetComponent<FirstPersonController2>();
        ml = Player.GetComponent<MouseLook>();
        cm = GetComponent<CharacterMotor>();
        rb = GetComponent<Rigidbody>();
        Gaze = GetComponent<GazeAwareComponent>();
        this.eyeXHost = GameObject.FindObjectOfType<EyeXHost>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (isInside == true && Input.GetKeyDown(KeyCode.E))
        {
            isLocked = true;
            mychar.enabled = false;
            cm.canControl = false;
          if (GetComponent<GazeAwareComponent>().HasGaze)
            {

                //here we want to start the statue to animate so we can proceed with the simon says process
                
                SimonSays();
                
            }
        }
        else if (isInside == true && Input.GetKeyDown(KeyCode.E) && isLocked == true)
        {
            mychar.enabled = true;
            cm.enabled = true;
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            isInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            isInside = false;
        }
    }
   
    /// <summary>
    /// Detect if the user is not having one eye opened or not (blinking)
    /// Doesn't work
    /// </summary>
    void SimonSays()
    {
        //http://developer.tobii.com/community/forums/topic/blink-detection/

        var provider = eyeXHost.GetEyePositionDataProvider();
        var LastgazePoint = _gazePointDataComponent.LastGazePoint;

        if (provider.Last.LeftEye.IsValid)
        {
           // var temp = new Vector2((LastgazePoint.Display.x), (LastgazePoint.Display.y - 100));
            Debug.Log("Left eye is looking?");
        }
        else
        {
            Debug.Log("Left eye is not looking");
        }
    }
}

