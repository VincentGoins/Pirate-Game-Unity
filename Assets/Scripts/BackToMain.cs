using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour
{

    public Button back;
    // Start is called before the first frame update
    void Start()
    {
       back.onClick.AddListener(GoBack);
    }

    void GoBack(){
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
