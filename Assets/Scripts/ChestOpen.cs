using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestOpen : MonoBehaviour
{
     [SerializeField]
    private bool chest;

     [SerializeField]
    private float opening;

    [SerializeField] 
    private Image Fill;
    [SerializeField] 
    private float count;

    [SerializeField] 
    private GameObject bar;

    private PirateMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        Fill.fillAmount = 0;
     chest = false;   
     opening = 300f;
     count = 0;
     bar.SetActive(false);
     pm = GetComponent<PirateMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //chest = pm.getChest();
        if(chest){
            
        count =count + 1;
            Fill.fillAmount = count/opening;
            
            if (count/opening ==1){
                bar.SetActive(false);
            }
        }
        else{
            count = 0;
            Fill.fillAmount = 0;
            //bar.SetActive(false);
        }
    }

    public void setOpening(bool op){
        chest = op;
    }
}
