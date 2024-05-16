using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI elementlerine eriþimimizi saðlýyor

public class Castle : MonoBehaviour
{
    public float totalHealth = 100f;
    [HideInInspector]// public olan bir deðeri gizlememize yarýyor ve debugda da gözükmüyor
    public float currentHealth;

    public Slider healthSlider;

    public Transform[] attackPoints;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = totalHealth;

        healthSlider.maxValue = totalHealth;
        healthSlider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            gameObject.SetActive(false); //can sýfýra eþit ya da daha küçük olursa active false olur yani kale yok olur
        }

        healthSlider.value = currentHealth; // healthslider deðerini current healtha eþitledim
    }
}
