using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Currency : MonoBehaviour
{

 public TextMeshProUGUI textFieldGold;
 private float goldAmount = 0;
    // Start is called before the first frame update
    void Start()
    {
       goldAmount = PlayerPrefs.GetFloat("Gold");
       textFieldGold.text = goldAmount.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        goldAmount = PlayerPrefs.GetFloat("Gold");
       textFieldGold.text = goldAmount.ToString(); 
    }
}
