using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HBar : MonoBehaviour
{

    private Health health;

    private void Setup(Health health)
    {
        this.health = health;
        health.OnHealthChanged += Health_OnHealthChanged;
    }

    private void Health_OnHealthChanged(object sender, System.EventArgs e){
        transform.Find("bar holder").localScale = new Vector3(health.GetHealthPercent(), 1);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
