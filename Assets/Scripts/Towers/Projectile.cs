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
        theRB.velocity = transform.forward * moveSpeed; // z ekseninde ileri hareket etmesini saðlýyoruz ball un
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && !hasDamaged)
        {
            other.GetComponent<EnemyHealthController>().TakeDamage(damageAmount);
            hasDamaged = true; // bu sayede tek seferde yalnýzca bir düþmana vurabilir.
        }
        Instantiate(impactEffect,transform.position,Quaternion.identity); // Quaternion.identity yerine transform.rotation da yazýlabilir
        //yukardaki quaternion.identity bize vector3 deðerini 000 a eþitliyor
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
