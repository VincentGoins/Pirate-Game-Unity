using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField]
    private float chest;

    [SerializeField]
    private bool secret;
    // Start is called before the first frame update
    void Start()
    {
        if(secret) chest = 10000f;
        else chest = Mathf.Round(Random.Range(-10f,50f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }



   public float Value(){
       return chest;
   }
}
