using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody theRB;
    public float moveSpeed;

    public GameObject impactEffect;


    // Start is called before the first frame update
    void Start()
    {
        theRB.velocity = transform.forward * moveSpeed; // z ekseninde ileri hareket etmesini saðlýyoruz ball un
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(impactEffect,transform.position,Quaternion.identity); // Quaternion.identity yerine transform.rotation da yazýlabilir
        //yukardaki quaternion.identity bize vector3 deðerini 000 a eþitliyor
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
