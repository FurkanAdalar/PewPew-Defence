using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTower : MonoBehaviour
{

    private Tower theTower;

    public GameObject projectile;
    public Transform firePoint;
    public float timeBetweenShots = 1f;
    private float shotCounter;
    // Start is called before the first frame update
    void Start()
    {
        theTower = GetComponent<Tower>();
    }

    // Update is called once per frame
    void Update()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0 )
        {
            shotCounter = timeBetweenShots;

            Instantiate(projectile, firePoint.position, firePoint.rotation);
        }
    }
}
