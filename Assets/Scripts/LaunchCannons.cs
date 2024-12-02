using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class LaunchCannons : MonoBehaviour
{
    [SerializeField]
    private GameObject cannonBall;

    [SerializeField]
    private GameObject leftCannons;

    [SerializeField]
    private GameObject rightCannons;

    [SerializeField]
    private float launchSpeed;

    [SerializeField]
    public int ammo;

    [SerializeField]
    private float heal;

    [SerializeField]
    private int healItems;

    [SerializeField]
    private TextMeshProUGUI cannonText;

    [SerializeField]
    private TextMeshProUGUI healText;

    [SerializeField]
    private AudioSource leftSource;

    [SerializeField]
    private AudioSource rightSource;

    [SerializeField]
    private AudioClip clip;

    [SerializeField]
    private GameObject cam2;

    [SerializeField]
    private bool onBoat;

    private pHealth playHealth;
    
    public int checkScene = 0;

  //  public OnClickAmmo ammoChange 

    //public int startAmount = 15;

  

// [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
   /* public void Initialize()
    {
        ammo = 10;
         cannonText.text = ammo.ToString();
    }*/
 public static LaunchCannons Instance;

   
    // Start is called before the first frame update
    void Start()
    {
      
    //  Initialize();
      /* */
       
       ammo = PlayerPrefs.GetInt("currAmmo");
       cannonText.text = ammo.ToString();
       ammo += PlayerPrefs.GetInt("ammo");
       PlayerPrefs.SetInt("currAmmo", ammo);
       cannonText.text = ammo.ToString();
       

         if(!PlayerPrefs.HasKey("ammo")){
            ammo = 15;
             cannonText.text = ammo.ToString();
             PlayerPrefs.SetInt("currAmmo", ammo);
        }

        healItems = PlayerPrefs.GetInt("currHealth");
        healText.text = healItems.ToString();
       healItems += PlayerPrefs.GetInt("health");
       PlayerPrefs.SetInt("currHealth", healItems);
       healText.text = healItems.ToString();

         if(!PlayerPrefs.HasKey("health")){
            healItems = 5;
             healText.text = healItems.ToString();
             PlayerPrefs.SetInt("currHealth", healItems);
        }
       
       

    //  cannonText.text = startAmount.ToString();
       playHealth = GetComponent<pHealth>();
       healText.text = healItems.ToString();
    }





 
    // Update is called once per frame
    void Update()
    {

        if(!cam2.activeSelf) onBoat =true;
        else onBoat = false;

            if(onBoat){
            Vector3 currPosition = transform.position;

             /* if(ammoChange.check > 0){
                checkScene++;
              }*/

             //if(checkScene > 0){
            
             // }

            if (Input.GetButtonDown("Left Fire"))
            {
                if (ammo>0){
                    ammo -=1;
                    cannonText.text = ammo.ToString();
                    PlayerPrefs.SetInt("currAmmo", ammo);
                    foreach(Transform child in leftCannons.transform)
                    {
                        GameObject projectile = Instantiate(cannonBall, child.position, child.rotation);
                        projectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchSpeed, 0));
                        Object.Destroy(projectile, 3.0f);
                    }
                    leftSource.PlayOneShot(clip);
                }
            }

            if (Input.GetButtonDown("Right Fire"))
            {
                if (ammo>0){
                    ammo -=1;
                    cannonText.text = ammo.ToString();
                    PlayerPrefs.SetInt("currAmmo", ammo);
                    foreach (Transform child in rightCannons.transform)
                    {
                        GameObject projectile = Instantiate(cannonBall, child.position, child.rotation);
                        projectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchSpeed, 0));
                        Object.Destroy(projectile, 3.0f);
                    }
                   rightSource.PlayOneShot(clip);
                }
            }

            if (Input.GetButtonDown("Heal")){
               if (healItems>0 && playHealth.GetHealth() != 1){
                   playHealth.UpdateHealth(heal);
                   healItems -= 1;
                   healText.text = healItems.ToString();
                    PlayerPrefs.SetInt("currHealth", healItems);
               }
            }

        }
        
    }

   public void UpdateAmmo(){
        ammo += 1;
        cannonText.text = ammo.ToString();
        PlayerPrefs.SetInt("currAmmo", ammo);
     
   }

    

   public void UpdateHealthItems(){
        healItems += 1;
        healText.text = healItems.ToString();
        PlayerPrefs.SetInt("currHealth", healItems);
   }

   public void OnApplicationQuit(){
    PlayerPrefs.DeleteAll();
   
   }

    
}
