using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class OnClickHealth : MonoBehaviour
{

    public Button shopHealth;
    public int amountClickedHealth;
    public TextMeshProUGUI textFieldHealth;
    private float goldAmount;
    //public Currency curr;
     //public static OnClickHealth onClickHealth;
    // Start is called before the first frame update
    void Start()
    {

        Scene currentScene = SceneManager.GetActiveScene ();
           // curr = new Currency();
         // Retrieve the name of this scene.
         string sceneName = currentScene.name;
      if(sceneName == "Shop"){
         amountClickedHealth = 0;
      PlayerPrefs.SetInt("health", amountClickedHealth);
    
      }
      
    // ammoIncrease = GameObject.FindGameObjectWithTag("Player").GetComponent<LaunchCannons>();
     shopHealth.onClick.AddListener(TaskOnClickHealth);
     //startAmmo = ammoIncrease.ammo;
    
     //ammoAmount = 
    }


   

    // Update is called once per frame
    void Update()
    {
     
     
      
    }

    public void TaskOnClickHealth(){
       
        goldAmount = PlayerPrefs.GetFloat("Gold");
        Debug.Log(goldAmount);
        if(goldAmount >= 5){
        amountClickedHealth++;
        goldAmount -= 5;
        }
        PlayerPrefs.SetFloat("Gold", goldAmount);
        textFieldHealth.text = amountClickedHealth.ToString(); 
        PlayerPrefs.SetInt("health", amountClickedHealth);

       
    } 
}
