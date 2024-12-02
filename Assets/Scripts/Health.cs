using System;
using UnityEngine;

public class Health : MonoBehaviour 
{
	public event EventHandler OnHealthChanged;

	 private float health;
		  private float healthCap;
   public Health(float healthCap){
	   this.healthCap = health;
	   health = healthCap;
   }

   public float GetHealth(){
	   return health;
   }

   public float GetHealthPercent(){
	   return (float)health/healthCap;
   }

   public void Damage(float damageAmount){
	   health -= damageAmount;
	   if (health<=0) health = 0;
	   if(OnHealthChanged != null) {
		   OnHealthChanged(this,EventArgs.Empty);
	   }
	   GetHealthPercent();
   }

   public void Heal(float healAmount){
	health += healAmount;   
   if (healAmount > healthCap){
		   health = healthCap;
	   }
	   if(OnHealthChanged != null) {
		   OnHealthChanged(this,EventArgs.Empty);
	   }
	   GetHealthPercent();
   }
   
}
