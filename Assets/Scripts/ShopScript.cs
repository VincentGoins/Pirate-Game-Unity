using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopScript : MonoBehaviour
{

  /*  public TextMeshProUGUI cannonText;

    public string ammoAmount;*/
    // Start is called before the first frame update
    
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
     //  ammoAmount = this.cannonText.text;
     if(PlayerPrefs.HasKey("EndGame")){
       gameObject.SetActive(false);
     }
    }

 void Awake(){
        DontDestroyOnLoad(this);
    }
    

	void OnCollisionEnter(Collision gameObjectInfo){
		if(gameObjectInfo.gameObject.name == "Player"){
		    SceneManager.LoadScene("Shop");
		}
	}
}
