using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2.0f;

    private bool isMovingToA = false;
    private enemycontroller inimigo;

    private void Awake()
    {
        inimigo = GetComponent<enemycontroller>();

    }

    private void Update()
    {
        if(inimigo.patrulha == true)
        {
            if (isMovingToA)
            {
                Vector3 direction = (pointA.position - transform.position).normalized;
                inimigo._rigidbody.MovePosition(transform.position + direction * inimigo.velocidade * Time.fixedDeltaTime);



                if (transform.position == pointA.position)
                {
                    isMovingToA = false;
                
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
            

                if (transform.position == pointB.position)
                {
                    isMovingToA = true;
                
                }
            }
        }
    }
}







