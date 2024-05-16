using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemySpawner : MonoBehaviour
{
    public EnemyController enemyToSpawn;
    
    public Transform spawnPoint;

    public float timeBetweenSpawns; // Enemy spawn bekleme s�resi
    private float spawnCounter;

    public int amountToSpawn = 10; // ka� tane enemy spawn oluca��
    // Start is called before the first frame update
    void Start()
    {
        spawnCounter = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if (amountToSpawn > 0) // spawn adedi s�f�rdan b�y�kse
        {
            spawnCounter -= Time.deltaTime;
            if (spawnCounter <= 0)
            {
                spawnCounter = timeBetweenSpawns;

                Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);

                amountToSpawn--; //spawn adedi 0 olana kadar counter� bir azalt�p s�f�r oldu�unda daha fazla spawnlanmaz
            }
        }
    }
}
