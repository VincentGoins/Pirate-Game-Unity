using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pHealth : MonoBehaviour
{
    public float health = 0;
    public float maxHealth;
    int checkUpdate = 0;

    private void Start (){
       //if(!(health < maxHealth)){
        health = maxHealth;
      // }
        //PlayerPrefs.SetFloat("pHealth", health);
        if(PlayerPrefs.HasKey("ammo") && (PlayerPrefs.GetInt("check") == 1)){
            health = PlayerPrefs.GetFloat("pHealth");
        }
    }

    public void UpdateHealth (float mod){
        health += mod;
        checkUpdate = 1;
        PlayerPrefs.SetInt("check", checkUpdate);
        if(health > 0){
        PlayerPrefs.SetFloat("pHealth", health);
        }
        /*else{
             //health = maxHealth;
             PlayerPrefs.SetFloat("pHealth", health);
        }*/
        if (health>maxHealth) health = maxHealth;
        else if (health <=0) Die();

    }

    public float GetHealth(){
        return health/maxHealth;
    }

    private void Die(){
        health = 0;
        SceneManager.LoadScene("Lose Screen");
    }
    
}
