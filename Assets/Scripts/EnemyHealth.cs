using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float health;

    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private Transform healthBar;

    [SerializeField]
    private GameObject uiHealthBar;

    [SerializeField]
    private bool isBB;

    private void Start(){
        health=maxHealth; 
         healthBar.transform.localScale = new Vector3(health/maxHealth, 1);
         uiHealthBar.SetActive(false);
    }

    public void Damage(float damage){
        health += damage;

        if(health<maxHealth) uiHealthBar.SetActive(true);

        if (health<=0) Die();
        healthBar.transform.localScale = new Vector3(health/maxHealth, 1);
    }

    private void Die(){
        Destroy(gameObject);
        if (isBB){
            SceneManager.LoadScene("Win Scene");
        }
    }

}
