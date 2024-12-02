using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] private float playerDamage;
    private void Start(){
        playerDamage *= -1;
    }

    void OnCollisionEnter(Collision other){
        if(other.collider.gameObject.CompareTag("Ship")){
            other.gameObject.GetComponent<EnemyHealth>().Damage(playerDamage);
        }
    }
}
