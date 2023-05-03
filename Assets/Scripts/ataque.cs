using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataque : MonoBehaviour
{
    public PlayerController player;
    public float dano;

    private void Awake()
    {
        dano = player.dano;
    }
    private void OnTriggerEnter(Collider other)
    {
        // Causa dano ao objeto que colidir com a espada
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemycontroller inimigo = other.gameObject.GetComponent<enemycontroller>();
            inimigo.ReceberDano(dano);
        }
        else if (other.gameObject.CompareTag("Boss"))
        {
            BossFirstBehavior boss = other.gameObject.GetComponent<BossFirstBehavior>();
            boss.ReceberDano(dano);
        }
    }

}
