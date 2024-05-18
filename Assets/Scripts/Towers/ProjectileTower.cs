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

    private Transform target;
    public Transform launcherModel;

    // Start is called before the first frame update
    void Start()
    {
        theTower = GetComponent<Tower>(); // tower scriptine eri�memize yar�yor
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            //launcherModel.LookAt(target);
            launcherModel.rotation =Quaternion.Slerp(launcherModel.rotation, Quaternion.LookRotation(target.position - transform.position), 5f*Time.deltaTime); //bu kod cannon �n targetlar aras� ge�i�te smoothluk sa�l�yor.

            launcherModel.rotation = Quaternion.Euler(0f, launcherModel.rotation.eulerAngles.y, 0f);
        }
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0 && target != null)
        {
            shotCounter = timeBetweenShots;

            firePoint.LookAt(target);

            Instantiate(projectile, firePoint.position, firePoint.rotation);
        }

        if(theTower.enemiesInRange.Count > 0 )
        {
            float minDistance = theTower.range + 1f; // min distance de�erini setledik
            foreach(EnemyController enemy in theTower.enemiesInRange)
            {
                if(enemy != null)
                {
                    float distance = Vector3.Distance(transform.position, enemy.transform.position);
                    if(distance < minDistance)
                    {
                        minDistance = distance; //en yak�ndaki enemy
                        target = enemy.transform;// ayn� �ekilde transformuna
                    }
                }
            }
        }
        else
        {
            target = null;
        }
    }
}
