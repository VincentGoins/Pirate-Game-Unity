using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timeStamp : MonoBehaviour
{
    public float timeEnd = 0;
    public string textInput = "Time: ";
    public TMP_Text textBox;
    public float finalTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = textInput + timeEnd.ToString("F0");
         
    }

    // Update is called once per frame
    void Update()
    {
        timeEnd += Time.deltaTime;
        PlayerPrefs.SetFloat("currTime", timeEnd);
        textBox.text = textInput + timeEnd.ToString("F0");
           if(PlayerPrefs.HasKey("newTime")){
            finalTime = PlayerPrefs.GetFloat("newTime") + timeEnd;
            PlayerPrefs.SetFloat("currTime", finalTime);
            textBox.text = textInput + finalTime.ToString("F0");

        }
    
    }
}
