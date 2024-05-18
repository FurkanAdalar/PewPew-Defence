using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthController : MonoBehaviour
{
    public float totalHealth;

    public Slider healthBar;


    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = totalHealth;
        healthBar.value = totalHealth;   
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.transform.rotation = Camera.main.transform.rotation; // main camera n�n rotation de�erini healthbara e�itliyoruz
    }

    public void TakeDamage(float damageAmount)
    {
        totalHealth -= damageAmount;
        if(totalHealth <= 0)
        {
            totalHealth = 0;
            Destroy(gameObject);
        }

        healthBar.value = totalHealth;
        healthBar.gameObject.SetActive(true);//sadece hasar ald�klar�nda can barlar�n�n g�z�kmesi i�in
    }
}
