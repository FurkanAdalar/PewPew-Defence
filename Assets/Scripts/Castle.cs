using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI elementlerine eri�imimizi sa�l�yor

public class Castle : MonoBehaviour
{
    public float totalHealth = 100f;
    private float currentHealth;

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
            gameObject.SetActive(false); //can s�f�ra e�it ya da daha k���k olursa active false olur yani kale yok olur
        }

        healthSlider.value = currentHealth; // healthslider de�erini current healtha e�itledim
    }
}
