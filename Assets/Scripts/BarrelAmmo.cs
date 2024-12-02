using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelAmmo : MonoBehaviour
{

 //public GameObject b;
   private LaunchCannons ammoIncrease;

   public void Start(){
    //a = new GameObject();
    ammoIncrease = GameObject.FindGameObjectWithTag("Player").GetComponent<LaunchCannons>();

   }
 public void OnCollisionEnter(Collision collider){
        
        if(collider.gameObject.tag == "Player"){
            ammoIncrease.UpdateAmmo();
            gameObject.SetActive(false);
        }
      
    }
}
