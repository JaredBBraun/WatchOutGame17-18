using UnityEngine;
using System.Collections;

public class NoteSound : MonoBehaviour {

    public AudioClip Sound;
    public float Volume;
    AudioSource audio;
    public bool alreadyPlayed = false;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter()
    {
        if (!alreadyPlayed)
        {
            audio.PlayOneShot(Sound, Volume);
            alreadyPlayed = true;
        }
    }
}
