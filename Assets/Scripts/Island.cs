using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{

    [SerializeField]
    private GameObject progress; 

    [SerializeField]
    private bool secret;
    
    [SerializeField]
    private bool check;

    [SerializeField]
    private Transform spawn;

    

    [SerializeField]
    private GameObject pirate;

    private Progress end;

    

    // Start is called before the first frame update
    void Start()
    {
     progress.SetActive(false);   
     check = false;
     end = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Progress>();
    }

    void Update(){
        
    }
   

    void OnCollisionEnter(Collision other){
        if(other.collider.gameObject.CompareTag("Player")){
            
            if (!check){
                progress.SetActive(true);  
                end.Outcome(secret);
                pirate.transform.position = spawn.transform.position;

            }
        }
    }

    void OnCollisionExit(Collision other){
        if(other.collider.gameObject.CompareTag("Player")){

            if (progress.activeInHierarchy == true){
                 progress.SetActive(false); 
            }
            else{
                check = true;
                
            }  
        }   
    }
    
    
}
