using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{

    public static FadeManager instance { set; get; }

    public Image fadeImage;
    private bool isInTransition;
    private float transition;
    private bool isShowing;
    private float duration;

    private void Awake()
    {
        instance = this;

    }
    public void Fade(bool showing,float duration)
    {
        isShowing = showing;
        isInTransition = true;
        this.duration = duration;
        transition = (isShowing) ? 0 : 1;
    }

    private void Update()


    {

        Scene currentScene = SceneManager.GetActiveScene();

        
        string sceneName = currentScene.name;


        if (sceneName == "TestScene")
        {
        Fade(true,1.25f);
        }

        //if (InputManager.BButton())
   // {
   //  Fade(false,3.0f);
   // }

        if (!isInTransition)
            return;
        transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
        fadeImage.color = Color.Lerp(new Color(1, 1, 1, 0), Color.black, transition);

        if (transition > 1 || transition < 0)
            isInTransition = false;
    }
}