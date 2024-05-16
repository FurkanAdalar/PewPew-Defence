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

    public Castle theCastle;
    public Path thePath;
    // Start is called before the first frame update
    void Start()
    {
        spawnCounter = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {

        if (amountToSpawn > 0 && theCastle.currentHealth >0) // spawn adedi sýfýrdan büyükse ve castle caný 0dan büyük olduðu sürece
        {
            spawnCounter -= Time.deltaTime;
            if (spawnCounter <= 0)
            {
                spawnCounter = timeBetweenSpawns;

                Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation).Setup(theCastle,thePath); //enemy controller type Instantiate
                //enemy controllerýna castle ve path i atýyoruz istediðimiz þekilde gitmesini saðlamýþ oluyoruz.
                amountToSpawn--; //spawn adedi 0 olana kadar counterý bir azaltýp sýfýr olduðunda daha fazla spawnlanmaz
            }
        }
    }
}
