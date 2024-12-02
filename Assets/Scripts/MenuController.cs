using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    [SerializeField]
    public static bool isPaused = false;

    public GameObject pauseMenu;

    //function to pause game
    public void Pause()
    {
      
    //    Debug.Break();
    }
        

    public void Resume() {
        isPaused = false;
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    public void Start()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    //checks for a pause on every frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && isPaused == false)
        {
          //  if (isPaused)
            //{
        isPaused = true;
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        Time.timeScale = 0f;
        AudioListener.pause = true;
            }
       else if(Input.GetKeyDown(KeyCode.P) && isPaused == true){
                //Resume();
                 isPaused = false;
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        Time.timeScale = 1f;
        AudioListener.pause = false;
            }
    }
    


    // Start is called before the first frame update
    public void ButtonPlay()
    {
        SceneManager.LoadScene(2);
    }

    public void ButtonContinue()
    {
        SceneManager.LoadScene(3);
    }

    // Update is called once per frame
    public void ButtonControls()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonQuit()
    {
        Application.Quit();
        Debug.Log("You Quit! Are the treacherous seas too much for you? ARGGG");

    }

    public void ButtonMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ButtonSettings()
    {
        SceneManager.LoadScene(7);
    }

    
}
