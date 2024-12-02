using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{

    [SerializeField] private Image Fill;
    [SerializeField] private float count;
    [SerializeField] private float show;
    [SerializeField]
    private GameObject progress;
    [SerializeField]
    private GameObject checkSystem;
    [SerializeField]
    private GameObject BB;
    [SerializeField]
    private float add;
    [SerializeField]
    private float timer;
    private float percent;
    private bool anchor;
    [SerializeField]
    private GameObject win;
    [SerializeField]
    private GameObject lose;
    [SerializeField]
    private GameObject black;

    [SerializeField]
    private AudioSource source;

    [SerializeField]
    private AudioClip clip;

    [SerializeField]
    private bool secret;
    private PlayerMovement pMove;
    private bool time;
     private bool end;

     [SerializeField]
    private GameObject cam2;

    [SerializeField]
    private GameObject found;

    private bool fight;


    

    
    // Start is called before the first frame update
    void Start()
    {
      //  checkSystem.SetActive(true);
        Fill.fillAmount = 0;
        add = 0;
        anchor=false;
        pMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        anchor = pMove.Anchor();
          time = false;
           fight = false;
        timer = 0;
        BB.SetActive(false);
        end = false;
       // checkSystem.SetActive(true);
        //win.SetActive(false); 
        //lose.SetActive(false); 
        if(PlayerPrefs.HasKey("EndGame")){
             end=true;
            fight =true;
            time = true;
              checkSystem.SetActive(false);
      
      
        }
    

       
    }

    // Update is called once per frame
    void Update()
    {
        anchor = pMove.Anchor();
        if (time){
            timer +=1 * Time.deltaTime;
        }
        if (anchor&&!end){
            add +=1 * Time.deltaTime;
            percent = add/count;
            Fill.fillAmount = percent;
        }
        else {
            add = 0;
            Fill.fillAmount = 0;
        }
        if(cam2.activeSelf) timer=0; 
        if (end && !cam2.activeSelf){
            black.SetActive(true);
            timer +=1 * Time.deltaTime;
        }
        if (end &&timer/show >=1){
            black.SetActive(false);
            end = false;
            BB.SetActive(true);
            source.clip = clip;
            source.Play();
            add = 0;
            found.SetActive(false);
            timer=0;
        }

        if (add>=count &&progress.activeSelf ){
            
            add =0;
            progress.SetActive(false); 
            Fill.fillAmount = 0;
            cam2.SetActive(true);
            percent =0;
            
        }
        
        if(found.activeSelf) {
            end=true;
            fight =true;
            time = true;
            PlayerPrefs.SetInt("EndGame", 1);
            
        }
        if(fight){
            checkSystem.SetActive(false);
        }
        
        
    }
   
    public void Outcome(bool outcome){
        secret = outcome;
    }
}
