using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Net;

namespace Unity.FPS.Game
{
public class ZombieHealth : MonoBehaviour
{
        [Tooltip("Health component to track")] public Health Health;

        [Tooltip("Image component displaying health left")]
        public Image HealthBarImage;

        [Tooltip("The floating healthbar pivot transform")]
        public Transform HealthBarPivot;

        [Tooltip("Whether the health bar is visible when at full health or not")]
        public bool HideFullHealthBar = true;
        public GameObject zombie;

	  public AudioSource Death;

		
	  void Start(){

		zombie = GameObject.Find("ZombieRig");

		}

        void Update()
        {
            // update health bar value
            HealthBarImage.fillAmount = Health.CurrentZombieHealth / Health.ZombieMaxHealth;

		if(Health.CurrentZombieHealth <= 0){
			
			Destroy(zombie);
			Death.Play();
			//Health.zombiesArray -= 1;
		}
		

            // rotate health bar to face the camera/player
            HealthBarPivot.LookAt(Camera.main.transform.position);

            // hide health bar if needed
            if (HideFullHealthBar)
                HealthBarPivot.gameObject.SetActive(HealthBarImage.fillAmount != 1);
        }
    }
}

