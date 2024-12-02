using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelHealth : MonoBehaviour
{
    // Start is called before the first frame update
   private GameObject a;
   private LaunchCannons healthIncrease;

   public void Start(){
    a = new GameObject();
    healthIncrease = GameObject.FindGameObjectWithTag("Player").GetComponent<LaunchCannons>();

   }
 public void OnCollisionEnter(Collision collider){
        
        if(collider.gameObject.tag == "Player"){
            healthIncrease.UpdateHealthItems();
            gameObject.SetActive(false);
        }
      
    }
}
