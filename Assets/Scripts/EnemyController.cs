using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;

    private Path thePath;
    private int currentPoint; //arraydeki tuttuklarýmýzý kullanmak için int þu an 0
    private bool reachedEnd;

    public float timeBetweenAttacks, damagePerAttack; // attaklar arasý bekleme süresi , attak baþý hasar
    private float attackCounter;

    private Castle theCastle;

    private int selectedAttackPoint;

    // Start is called before the first frame update
    void Start()
    {
        if (thePath == null)
        {
            thePath = FindObjectOfType<Path>();
        }
        if (theCastle == null)
        {
            theCastle = FindObjectOfType<Castle>();
        }
        attackCounter = timeBetweenAttacks;
    }

    // Update is called once per frame
    void Update()
    {
        if (theCastle.currentHealth > 0)// castle caný 0dan büyük olduðu sürece enemyler hareket edebilir yoksa durur.
        {
            if (!reachedEnd)
            {
                transform.LookAt(thePath.points[currentPoint].position);// düþmanýn baktýðý yönü deðiþtiriyor

                transform.position = Vector3.MoveTowards(transform.position, thePath.points[currentPoint].position, moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, thePath.points[currentPoint].position) < .01f)//distance between where we currently are
                {
                    currentPoint = currentPoint + 1;
                    if (currentPoint >= thePath.points.Length)
                    {
                        reachedEnd = true;

                        selectedAttackPoint = Random.Range(0, theCastle.attackPoints.Length);
                    }
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, theCastle.attackPoints[selectedAttackPoint].position, moveSpeed * Time.deltaTime);
                attackCounter -= Time.deltaTime;
                if (attackCounter <= 0)
                {
                    attackCounter = timeBetweenAttacks;

                    theCastle.TakeDamage(damagePerAttack);
                }
            }
        }
    }

    public void Setup (Castle newCastle, Path newPath)// enemylerin hangi kaleye hangi yoldan gidebileceklerini seçmemize olanak saðlýyor Setup fonksiyonu.
    {
        theCastle = newCastle;
        thePath = newPath;
    }
}
