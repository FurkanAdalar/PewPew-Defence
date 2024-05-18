using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 3f;
    public LayerMask whatIsEnemy; //layer se�memize yar�yor
    
    private Collider[] colliderInRange;
    public List<EnemyController> enemiesInRange = new List<EnemyController>(); //listede ekleme ��karma i�lemleri �ok kolay

    private float checkCounter;
    public float checkTime = .2f;

    // Start is called before the first frame update
    void Start()
    {
        checkCounter = checkTime;
    }

    // Update is called once per frame
    void Update()
    {
        checkCounter -= Time.deltaTime; //her framede yenilemenin �n�ne ge�erek biraz daha performas� geli�tiriyoruz
        if (checkCounter <= 0)
        {
            checkCounter = checkTime;

            colliderInRange = Physics.OverlapSphere(transform.position, range, whatIsEnemy);

            enemiesInRange.Clear();
            foreach (Collider col in colliderInRange)
            {
                enemiesInRange.Add(col.GetComponent<EnemyController>());
            }
        }
    }
}
