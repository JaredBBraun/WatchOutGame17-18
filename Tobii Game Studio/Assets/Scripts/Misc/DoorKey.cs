using UnityEngine;
using System.Collections;
//used youtube tutorial


public class DoorKey : MonoBehaviour
{
    public AudioClip KeySound;
    public bool inTrigger;

    void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.CompareTag ("Player")) {
			inTrigger = true;
		}
    }

    void OnTriggerExit(Collider other)
    {
		if (other.gameObject.CompareTag ("Player")) {
			inTrigger = false;
		}
    }

    void Update()
    {
        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerHasKey.key = true;
                AudioSource.PlayClipAtPoint(KeySound, transform.position);
                Destroy(this.gameObject);
            }
        }
    }

    void OnGUI()
    {
        if (inTrigger)
        {
            GUI.Box(new Rect(0, 60, 200, 25), "Press E to take key");
        }
    }
}