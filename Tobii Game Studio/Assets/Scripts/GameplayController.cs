using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class GameplayController : MonoBehaviour {


    
    public GameObject ThePlayer;
    public bool useMouse;
    bool isPaused = false;
    public GameObject PausePanel;
    private FirstPersonController myscript;
    public Animator GameOver;

    // Use this for initialization
    void Start () {
        isPaused = false;
         myscript = ThePlayer.GetComponentInChildren<FirstPersonController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused == false)
            {
                PauseTheGame();
            }
            else if(isPaused == true)
            {
                ResumeTheGame();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
           // LoadTheNextLevel();
           //this was for testing dont include in final build
        }

        ToggleMe();
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Time.timeScale = 1f;
            Cursor.visible = useMouse;

        }
        


    }

    /// <summary>
    /// dfgfdsgdfg
    /// </summary>
    public void PauseTheGame()
    {

        Time.timeScale = 0f;
        isPaused = true;
        myscript.GetComponent<FirstPersonController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeTheGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        myscript.GetComponent<FirstPersonController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void ToggleMe()
    {
        PausePanel.SetActive(isPaused);
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }

    public void LoadTheNextLevel()
    {
        int indexSC = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexSC + 1);
        Time.timeScale = 1f;
    }

    public void LoadTheMainMenu()
    {
       
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        myscript.GetComponent<FirstPersonController>().enabled = true;
        
    }


}

