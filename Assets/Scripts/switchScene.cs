using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         Scene currentScene = SceneManager.GetActiveScene ();
 
         // Retrieve the name of this scene.
         string sceneName = currentScene.name;
      if((sceneName == "Main Menu") || (sceneName == "Lose Screen") || (sceneName == "Win Scene") ){
        PlayerPrefs.DeleteAll();
      }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
