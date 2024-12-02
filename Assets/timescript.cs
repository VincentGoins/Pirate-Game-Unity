using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class timescript : MonoBehaviour
{
    private float time = 0;
    public TMP_Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        time = PlayerPrefs.GetFloat("currTime");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        PlayerPrefs.SetFloat("newTime", time);
        timeText.text = time.ToString("F0");
        
    }
}
