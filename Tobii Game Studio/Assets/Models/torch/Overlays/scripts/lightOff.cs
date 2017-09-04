using UnityEngine;
using System.Collections;

public class lightOff : MonoBehaviour
{
    public GameObject light_off;
    public GameObject flam;

    private void OnTriggerExit()
    {

        light_off.SetActive(false);
        flam.SetActive(false);
    }

}
