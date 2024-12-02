using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannonBall : MonoBehaviour
{
    [SerializeField] private float enemyDamage;
    private void Start(){
        enemyDamage *= -1;
        
    }

    void OnCollisionEnter(Collision other){
        if(other.collider.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<pHealth>().UpdateHealth(enemyDamage);
        }
    }
}
