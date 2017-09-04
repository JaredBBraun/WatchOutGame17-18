//Code based on Sai Mulpuru's code from http://developer.tobii.com/community/forums/topic/unity-manipulate-camera-2/
// which is based on the tobii standard assets character controller

using UnityEngine;
using System.Collections;
using Tobii.EyeX.Framework;
using UnityStandardAssets.CrossPlatformInput;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// – Create a capsule.
/// – Add the MouseLook script to the capsule.
/// -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// – Add FPSInputController script to the capsule
/// -> A CharacterMotor and a CharacterController component will be automatically added.

/// – Create a camera. Make the camera a child of the capsule. Reset it’s transform.
/// – Add a MouseLook script to the camera.
/// -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera - Control / Gaze Look")]
public class gazeLook : MonoBehaviour
{

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 1F;
	public float sensitivityY = 1F;

	public float minimumX = -360F;
	public float maximumX = 360F;

	public float minimumY = -60F;
	public float maximumY = 60F;

	private Quaternion maxY = new Quaternion(280.0f, 0, 0, 0);
	private Quaternion minY = new Quaternion(90.0f, 0, 0, 0);

	private EyeXHost _eyeXHost;
	private IEyeXDataProvider<EyeXFixationPoint> _fixationDataProvider;
	private int _fixationCount;
	//private GazePointDataComponent _gazePointDataComponent;

	#if UNITY_EDITOR
	private FixationDataMode _oldFixationDataMode;
	#endif

	/// <summary>
	/// Choice of fixation data stream to be visualized.
	/// </summary>
	public FixationDataMode fixationDataMode = FixationDataMode.Sensitive;

	float rotationY = 0;
	float rotationX = 0;

	public void Awake()
	{
		_eyeXHost = EyeXHost.GetInstance();
		_fixationDataProvider = _eyeXHost.GetFixationDataProvider(fixationDataMode);

		#if UNITY_EDITOR
		_oldFixationDataMode = fixationDataMode;
		#endif
	}

	public void OnEnable()
	{
		_fixationDataProvider.Start();
	}

	public void OnDisable()
	{
		_fixationDataProvider.Stop();
	}

	void Update()
	{
		var fixationPoint = _fixationDataProvider.Last;
		float gazeX = (2f * ((float)fixationPoint.GazePoint.Viewport.x - 0.5f));
		float gazeY = (2f * ((float)fixationPoint.GazePoint.Viewport.y - 0.5f));

		if (axes == RotationAxes.MouseXAndY)
		{
			Debug.Log("Mouse x and y were set");  //put this on the camera for MOUSE control of up/down axis
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			//Debug.Log("Mouse was in the range to rotate by: " + rotationY);
			if (rotationY <-30)
				rotationY = -30;
			if (rotationY >45)
				rotationY = 45;
			transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
		}
		else if (axes == RotationAxes.MouseX)
		{
			Debug.Log("Mouse X was set");  //put this on the parent controller for Tobii left/right axis

			if ((float)fixationPoint.GazePoint.Viewport.x >= 0 && (float)fixationPoint.GazePoint.Viewport.x <= 1)
				transform.Rotate(0, gazeX * sensitivityX/2, 0);
		}
		else if (axes == RotationAxes.MouseY)
		{
			Debug.Log("Mouse Y was set");  //put this on the camera for Tobii up/down axis
			if ((float)fixationPoint.GazePoint.Viewport.y >= .7f || (float)fixationPoint.GazePoint.Viewport.y <= .5f)
			{
				rotationY -= transform.localEulerAngles.y - (gazeY * sensitivityY);
				//Debug.Log("Tobii Y was in the range to rotate by: " + rotationY);
				if (rotationY <-30)
					rotationY = -30;
				if (rotationY >30)
					rotationY = 30;
				transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
			}
		}
	}

	void Start()
	{
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;
	}
}
