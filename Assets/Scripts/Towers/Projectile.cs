using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody theRB;
    public float moveSpeed;

    public GameObject impactEffect;

    public float damageAmount;

    private bool hasDamaged;

    // Start is called before the first frame update
    void Start()
    {
        theRB.velocity = transform.forward * moveSpeed; // z ekseninde ileri hareket etmesini sa�l�yoruz ball un
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && !hasDamaged)
        {
            other.GetComponent<EnemyHealthController>().TakeDamage(damageAmount);
            hasDamaged = true; // bu sayede tek seferde yaln�zca bir d��mana vurabilir.
        }
        Instantiate(impactEffect,transform.position,Quaternion.identity); // Quaternion.identity yerine transform.rotation da yaz�labilir
        //yukardaki quaternion.identity bize vector3 de�erini 000 a e�itliyor
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
