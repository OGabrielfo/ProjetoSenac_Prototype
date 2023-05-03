using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAtaque : MonoBehaviour
{
    public BossFirstBehavior boss;
    public float dano;

    private void Awake()
    {
        dano = boss.dano;
    }
    private void OnTriggerEnter(Collider other)
    {
        // Causa dano ao objeto que colidir com a espada
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            player.ReceberDano(dano);
        }
    }

}
