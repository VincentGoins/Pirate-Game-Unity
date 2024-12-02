using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float floatForwardSpeed;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private bool anchorDown;

    [SerializeField]
    private int speedBoostFactor;

    [SerializeField]
    private bool isPaused;

    [SerializeField]
    private bool onBoat;

    [SerializeField]
    private GameObject cam2;



    public float xRange;
    public float zRange;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("ammo")){
        transform.position = new Vector3(3039f, 5.0612f, 298.09f);
        }
    }

    void PauseGame() {
        if (isPaused)
        {
            Time.timeScale = 0;
            AudioListener.pause = true;
        }
        else {
            Time.timeScale = 1;
            AudioListener.pause = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            isPaused = !isPaused;
            PauseGame();
        }
        if(!cam2.activeSelf) onBoat =true;
        else onBoat=false;

        if(onBoat){
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

           if(transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }

            if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }

            if (transform.position.z > zRange)
            {
                transform.position = new Vector3( transform.position.x, transform.position.y, zRange);
            }

            if (transform.position.z < -zRange)
            {
                transform.position = new Vector3( transform.position.x, transform.position.y, -zRange);
            }

            if (Input.GetButtonDown("Anchor Down"))
            {
                anchorDown = !anchorDown;
            } 

            Vector3 movementDirection = new Vector3(transform.forward.x, 0, transform.forward.z);

            if (anchorDown)
            {
                movementDirection = Vector3.zero;
                transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
            }
            else
            {
                movementDirection = Quaternion.AngleAxis(horizontalInput, Vector3.up) * movementDirection;
                movementDirection = new Vector3(movementDirection.x, 0, movementDirection.z);
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }

            if (verticalInput > 0)
            {
                movementDirection = speedBoostFactor * movementDirection;
            }

            transform.Translate(floatForwardSpeed * Time.deltaTime * movementDirection, Space.World);
        }
    }

    public bool Anchor(){
        return anchorDown;
    }

    public void isOnBoat(bool value){
        onBoat = value;
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
    
}