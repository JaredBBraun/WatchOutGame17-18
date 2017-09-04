using UnityEngine;
using Tobii.EyeX.Framework;

public class MyLookAt : MonoBehaviour
{
    [SerializeField]
    private Camera eyeCamera;
    EyeXHost eyeXHost;
    public GazePointDataComponent _gazePointDataComponent;

    void Start()
    {
        this.eyeXHost = GameObject.FindObjectOfType<EyeXHost>();
        Debug.Log("We have the eyex host");
    }

    Vector2 GetEyeGazePoint()
    {

        //Say it gets destroyed before this gets destroyed
        if (eyeXHost == null)
        {
            return Vector2.zero;
        }

        //http://developer.tobii.com/community/forums/topic/get-eye-screen-coordinates-and-match-it-with-a-unity-game-object/

        var displaySize = eyeXHost.DisplaySize;
        var screenBounds = eyeXHost.ScreenBounds;
        var provider = eyeXHost.GetEyePositionDataProvider();
        var LastgazePoint = _gazePointDataComponent.LastGazePoint;

        if (provider.Last.IsValid)
        {
            //get ave position of eyes in pixels
          //  Debug.Log("Its working ");
            var temp = new Vector2((LastgazePoint.Display.x), (LastgazePoint.Display.y - 100));
           // Debug.Log(temp);
            return temp;

            //return new Vector2( LastgazePoint.Display.x, LastgazePoint.Display.y);
            // (provider.Last.LeftEye.X + provider.Last.RightEye.X) / 2,
            //(provider.Last.LeftEye.Y + provider.Last.RightEye.Y) / 2);

        }
        else
        {
            //look foward at center of screen
           // Debug.Log("invalid");
            return new Vector2(Screen.width / 2, Screen.height / 2);
        }

        //throw new System.NotImplementedException("Please Implement using Tobii SDK API");
    }

    public void Update()
    {
        Look(transform);
    }


    /// <summary>
    /// Suggested by Anthony Popp
    /// </summary>
    /// <param name="eyeGazePoint">Pixel Position in screen</param>
    /// <param name="lookTransform">transform to rotate where you are looking </param>
    public void Look(Transform lookTransform)
    {
        //assumes that players is sitting in middle of screen where
        //looking foward at the center of the screen is the resting position
        Vector2 eyeGazePoint = GetEyeGazePoint();

        //bottom left of screen is (0,0), z is ignored
        Ray ray = eyeCamera.ScreenPointToRay(new Vector3(eyeGazePoint.x, eyeGazePoint.y, 0));

        Vector3 origin = ray.origin;
        Vector3 direction = ray.direction;

        //Tobii cannot track eye focus, so honing the flashlight based on where their eyes are focusing depth wise is useless

        // get a faraway distance so that the flashlight will point in same direction as eyes
        Vector3 destination = origin + direction * 100000.0f;

        Vector3 lookPosition = lookTransform.position;
        Vector3 lookFoward = destination - lookPosition;
        lookFoward.y = -lookFoward.y;
        Vector3 lookFowardNormalized = lookFoward.normalized;

        Quaternion lookRotation = Quaternion.LookRotation(lookFowardNormalized, Vector3.up);
        lookTransform.rotation = lookRotation;
    }
}