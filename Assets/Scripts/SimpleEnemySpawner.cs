using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemySpawner : MonoBehaviour
{
    public EnemyController enemyToSpawn;
    
    public Transform spawnPoint;

    public float timeBetweenSpawns; // Enemy spawn bekleme süresi
    private float spawnCounter;

    public int amountToSpawn = 10; // kaç tane enemy spawn olucaðý
    // Start is called before the first frame update
    void Start()
    {
        spawnCounter = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if (amountToSpawn > 0) // spawn adedi sýfýrdan büyükse
        {
            spawnCounter -= Time.deltaTime;
            if (spawnCounter <= 0)
            {
                spawnCounter = timeBetweenSpawns;

                Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);

                amountToSpawn--; //spawn adedi 0 olana kadar counterý bir azaltýp sýfýr olduðunda daha fazla spawnlanmaz
            }
        }
    }
}
