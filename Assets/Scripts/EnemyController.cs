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

    // Start is called before the first frame update
    void Start()
    {
        thePath = FindObjectOfType<Path>();

        theCastle = FindObjectOfType<Castle>();

        attackCounter = timeBetweenAttacks;
    }

    // Update is called once per frame
    void Update()
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
                }
            }
        }
        else
        {
            attackCounter -= Time.deltaTime;
            if(attackCounter <= 0)
            {
                attackCounter = timeBetweenAttacks;

                theCastle.TakeDamage(damagePerAttack);
            }
        }
    }
}
