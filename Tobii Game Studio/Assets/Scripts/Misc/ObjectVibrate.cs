using UnityEngine;
using System.Collections;

public class ObjectVibrate : MonoBehaviour {
    private Vector3 originPosition;
    private Quaternion originRotation;
    private float shake_decay = 0.000f;
    private float shake_intensity = .0f;



    private float temp_shake_intensity = 0;

    void Start()
    {
		

    }
    void Update()
    {


        if (temp_shake_intensity > 0)
        {
            transform.position = originPosition + Random.insideUnitSphere * temp_shake_intensity;
            transform.rotation = new Quaternion(
                originRotation.x + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRotation.y + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRotation.z + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRotation.w + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f);
            temp_shake_intensity -= shake_decay;
        }
    }

    void Shake()
    {
        originPosition = transform.position;
        originRotation = transform.rotation;
        temp_shake_intensity = shake_intensity;

    }

    private void OnTriggerEnter(Collider other)
    {
		Renderer rend = GetComponent<Renderer>();
		rend.sharedMaterial.SetColor ("_Color", Color.green);
        shake_intensity = .01f;
        Shake();
    }
    private void OnTriggerExit(Collider other)
    {
        shake_intensity = .00f;
		Renderer rend = GetComponent<Renderer>();
		rend.sharedMaterial.SetColor ("_Color", Color.blue);
        Shake();

    }

}