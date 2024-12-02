using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class OnClickAmmo : MonoBehaviour
{

    public Button shopAmmo;
    public float startAmmo;
    //public Currency curr;
   
    private LaunchCannons ammoIncrease;
     //[SerializeField]
    private string ammoAmount;
    public string ammoCount;
   // public OnClickAmmo changeText;
    public int check = 0;
    public TextMeshProUGUI textField;
    public static OnClickAmmo onClick;
   // public GameObject get;
   public int amountClicked;
   private float goldAmount;
    /* [SerializeField]
     

     

     public float Value{
        get{return amountClicked;}
        set{amountClicked = value;}
     }*/

    /* private void Awake(){
      if(onClick == null){
        onClick = this;
        DontDestroyOnLoad(gameObject);
      }
      else{
        Destroy(gameObject);
      }
     }*/
    
    // Start is called before the first frame update
    void Start()
    {

        Scene currentScene = SceneManager.GetActiveScene ();
         string sceneName = currentScene.name;
      if(sceneName == "Shop"){
        amountClicked = 0;
      PlayerPrefs.SetInt("ammo", amountClicked);
    
      }
      
     ammoIncrease = GameObject.FindGameObjectWithTag("Player").GetComponent<LaunchCannons>();
     shopAmmo.onClick.AddListener(TaskOnClick);
     
    }


   

    // Update is called once per frame
    void Update()
    {
     
     
      
    }

    public void TaskOnClick(){
        
         goldAmount = PlayerPrefs.GetFloat("Gold");
        //Debug.Log(goldAmount);
        if(goldAmount >= 20){
          amountClicked++;
          goldAmount -= 20;
        }
        PlayerPrefs.SetFloat("Gold", goldAmount);
        textField.text = amountClicked.ToString(); 
        PlayerPrefs.SetInt("ammo", amountClicked);
       
    } 
}
