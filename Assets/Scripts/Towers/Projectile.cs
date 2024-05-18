using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody theRB;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        theRB.velocity = transform.forward * moveSpeed; // z ekseninde ileri hareket etmesini saðlýyoruz ball un
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
