using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 3f;
    public LayerMask whatIsEnemy; //layer seçmemize yarýyor
    
    private Collider[] colliderInRange;
    public List<EnemyController> enemiesInRange = new List<EnemyController>(); //listede ekleme çýkarma iþlemleri çok kolay

    private float checkCounter;
    public float checkTime = .2f;

    [HideInInspector]
    public bool enemiesUpdated;

    // Start is called before the first frame update
    void Start()
    {
        checkCounter = checkTime;
    }

    // Update is called once per frame
    void Update()
    {
        enemiesUpdated = false;

        checkCounter -= Time.deltaTime; //her framede yenilemenin önüne geçerek biraz daha performasý geliþtiriyoruz
        if (checkCounter <= 0)
        {
            checkCounter = checkTime;

            colliderInRange = Physics.OverlapSphere(transform.position, range, whatIsEnemy);

            enemiesInRange.Clear();
            foreach (Collider col in colliderInRange)
            {
                enemiesInRange.Add(col.GetComponent<EnemyController>());
            }

            enemiesUpdated = true;
        }
    }
}
