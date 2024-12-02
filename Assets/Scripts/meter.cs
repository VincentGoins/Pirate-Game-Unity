using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meter : MonoBehaviour
{

    [SerializeField] private Image Fill;
    private pHealth playHealth;
    // Start is called before the first frame update
    void Start()
    {
     playHealth = GameObject.FindWithTag("Player").GetComponent<pHealth>();   
    }

    // Update is called once per frame
    void Update()
    {
      //  if(!PlayerPrefs.HasKey("ammo")){
        Fill.fillAmount = 1 - playHealth.health/playHealth.maxHealth;
        //}
        /*if(PlayerPrefs.HasKey("ammo")){
       Fill.fillAmount = 1 - PlayerPrefs.GetFloat("pHealth")/playHealth.maxHealth;
        }*/
    }
}
