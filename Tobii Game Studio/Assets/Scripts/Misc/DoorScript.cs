using UnityEngine;
using System.Collections;

//used youtube tutorial

public class DoorScript : MonoBehaviour
{

    public static bool doorKey;
    public AudioClip DoorOpen;
    public AudioClip DoorClose;
    public bool isLocked;
    public bool open;
    public bool close;
    public bool inTrigger;
    public bool isBlocked;

    void Start()
    {
        inTrigger = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inTrigger = false;
        }
    }

    void Update()
    {
        //Debug.Log("isLocked" + isLocked);
        if (inTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (close)
            {
                if (isLocked && !isBlocked)
                {
                    //Debug.Log("Door requires a key");
                    if (PlayerHasKey.key == true)
                    {
                        open = true;
                        close = false;
                        PlayerHasKey.key = false;
                        isLocked = false;
                        AudioSource.PlayClipAtPoint(DoorOpen, transform.position);


                    }
                }
                else
                {
                   // Debug.Log("Door doesn't need a key");
                    open = true;
                    close = false;

                    AudioSource.PlayClipAtPoint(DoorOpen, transform.position);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    close = true;
                    open = false;

                    AudioSource.PlayClipAtPoint(DoorClose, transform.position);
                }
            }
        }



        if (open)
        {
            var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, -90.0f, 0.0f), Time.deltaTime * 200);
            transform.rotation = newRot;
        }
        else
        {
            var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 0.0f, 0.0f), Time.deltaTime * 200);
            transform.rotation = newRot;
        }
    }

    void OnGUI()
    {
        if (inTrigger && !isBlocked)
        {
            if (open)
            {
                GUI.Box(new Rect(500, 500, 200, 25), "Press E to close");
            }
            else
            {
                if (doorKey || !isLocked)
                {
                    GUI.Box(new Rect(500, 500, 200, 25), "Press E to open");
                }
                else
                {
                    GUI.Box(new Rect(500, 500, 200, 25), "Need a key!");
                }
            }
        }
        else if (isBlocked)
        {
            GUI.Box(new Rect(500, 500, 200, 25), "I don't think it will open!");
        }
    }
}