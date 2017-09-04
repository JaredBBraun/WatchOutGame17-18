using UnityEngine;
 
public class SpinOnGaze : MonoBehaviour 
{
    private GazeAwareComponent _gazeAware;
 
    void Start () 
    {
        _gazeAware = GetComponent<GazeAwareComponent>();
    }
 
    void Update () 
    {
        if (_gazeAware.HasGaze) 
        {
            transform.Rotate(Vector3.forward);
        }
    }
}