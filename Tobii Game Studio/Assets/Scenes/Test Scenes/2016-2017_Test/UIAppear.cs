using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIAppear : MonoBehaviour {


    //[SerializeField] 
    public Text tutText;

    private void Start()
    {
        tutText.enabled = false;
    }

   void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tutText.enabled = true;
        }  
    }

void OnTriggerExit(Collider other)
{
    if (other.CompareTag("Player"))
    {
        tutText.enabled = false;
    }
}
}
