using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
[DisallowMultipleComponent]
    [RequireComponent(typeof(Collider))]

public class PirateMovement : MonoBehaviour
{
    
    [SerializeField]
    private bool onBoat;

    [SerializeField]
    private bool goBack;

    [SerializeField]
    private GameObject cam2;
    
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private Transform cameraTransform;

    [SerializeField]
    private bool chest;

    [SerializeField]
    private float gold;

    [SerializeField]
    private float finalTime;

    [SerializeField]
    private float count;

    [SerializeField]
    private float total;

    [SerializeField]
    private float timer;

    [SerializeField]
    private GameObject win;

    [SerializeField]
    private GameObject lose;
    
    [SerializeField]
    private GameObject AllGold;

    [SerializeField]
    private TextMeshProUGUI goldCount;

    [SerializeField]
    private GameObject checkSystem;

    [SerializeField]
    private GameObject found;

    [SerializeField]
    private GameObject pirate;

    private CharacterController charCon;
    private Transform pirateTransform;
    private GameObject boxes;
    private ChestOpen open;
    private Animator ani;
    private float ySpeed;
    private PlayerMovement pMove;
    


    // Start is called before the first frame update
    void Start()
    {
        charCon = GetComponent<CharacterController>();
        ani = GetComponent<Animator>();
        chest = false;
        timer =0;

          if(!PlayerPrefs.HasKey("ammo")){
          //total = 0;
          PlayerPrefs.SetFloat("Gold", total);
         }
        total = PlayerPrefs.GetFloat("Gold");
          goldCount.text = total.ToString();
       


        open = GetComponent<ChestOpen>();
        win.SetActive(false);
        lose.SetActive(false);
         AllGold.SetActive(false);
        goldCount.text = total.ToString();
        pMove = GetComponent<PlayerMovement>();
        onBoat = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cam2.activeSelf){
            onBoat =false;
            checkSystem.SetActive(false);
        }
        else{
            onBoat = true;
            checkSystem.SetActive(true);
        }
        if (!onBoat){
             
            
        
        if (Input.GetButton("Heal") && goBack){
            timer +=1*Time.deltaTime;
            if(timer>=3){
                onBoat = true;
                cam2.SetActive(false);
                checkSystem.SetActive(true);
            }
        }
        else if (Input.GetButton("Heal") && chest){
            count = 0;
                ani.SetBool("Opening", true);
                timer +=1*Time.deltaTime;
                if (timer >= 2.5){
                    count = 0;
                    total += gold;
                    chest = false;
                    goldCount.text = total.ToString();
                    PlayerPrefs.SetFloat("Gold", total);
                    boxes.SetActive(false);
                    if(gold ==10000) {
                        found.SetActive(true);
                        AllGold.SetActive(true);
                    }
                    else if(gold>0) win.SetActive(true);
                    else lose.SetActive(true);
                }

            }
            else{
                count +=1 * Time.deltaTime;
                ani.SetBool("Opening", false);
                timer = 0;
            
                float horizontalInput = Input.GetAxis("Horizontal");
                float verticalInput = Input.GetAxis("Vertical");

                Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
                float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        
                movementDirection.Normalize();
        
                 movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
                charCon.SimpleMove(movementDirection * magnitude);
                //transform.Translate(movementDirection * speed * magnitude * Time.deltaTime, Space.World);

                if (movementDirection != Vector3.zero)
                {
                    ani.SetBool("IsMoving", true);
                    Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

                }
                else
                {
                    ani.SetBool("IsMoving" ,false);
            
                }
                if(count>=finalTime){
                    win.SetActive(false);
                    lose.SetActive(false);
                    AllGold.SetActive(false);
                }
            }
        }
    }

    /*private void OnApplicationFocus(bool focus){
        if (focus)
        {
            Cursor.lockState=CursorLockMode.Locked;
        }
        else{
            Cursor.lockState = CursorLockMode.None;
        }
    }*/

    public void setChest(bool connect){
        chest = connect;
    }

    public bool getChest(){
        return chest;
    }
   
    
     void OnControllerColliderHit(ControllerColliderHit hit){
        
        if(hit.collider.gameObject.CompareTag("Chest")){
            chest = true;
            boxes = hit.collider.gameObject;
            gold = boxes.GetComponent<Chest>().Value();
            goBack = false;
        }
        if(hit.collider.gameObject.CompareTag("Boat")){
            goBack = true;
            chest = false;
        }
    }
    
     

    

}
