using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;

    private Path thePath;
    private int currentPoint; //arraydeki tuttuklar�m�z� kullanmak i�in int �u an 0
    private bool reachedEnd;

    public float timeBetweenAttacks, damagePerAttack; // attaklar aras� bekleme s�resi , attak ba�� hasar
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
        if (theCastle.currentHealth > 0)// castle can� 0dan b�y�k oldu�u s�rece enemyler hareket edebilir yoksa durur.
        {
            if (!reachedEnd)
            {
                transform.LookAt(thePath.points[currentPoint].position);// d��man�n bakt��� y�n� de�i�tiriyor

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

    public void Setup (Castle newCastle, Path newPath)// enemylerin hangi kaleye hangi yoldan gidebileceklerini se�memize olanak sa�l�yor Setup fonksiyonu.
    {
        theCastle = newCastle;
        thePath = newPath;
    }
}
