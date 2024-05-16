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
            transform.LookAt(thePath.points[currentPoint].position);// düþmanýn baktýðý yönü deðiþtiriyor

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
