using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossFirstBehavior : MonoBehaviour
{
    public float vida;
    public float vidaMax;



    private Rigidbody _rigidbody;
    private Animator _anim;

    private bool _isChasing = false;
    private bool _battleStart = false;
    private bool _isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody= GetComponent<Rigidbody>();
        _anim= GetComponent<Animator>();
        vida = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (_battleStart)
        {
            if (vidaMax >= (vida / 2))
            {
                StartCoroutine("FirstBehavior");
            }
            else
            {
                StartCoroutine("SecondBehavior");
            }
        }
        if (vida <= 0)
        {
            _isDead = true;
            _anim.SetTrigger("Dead");
        }
    }

    private void LateUpdate()
    {
        

    }
    /*
    IEnumerator FirstBehavior()
    {

    }

    IEnumerator SecondBehavior()
    {

    }
    */

    public void TakeDamage(float damage)
    {
        vida -= damage;
        
    }

    public void Dead()
    {
        Destroy(gameObject);
    }
}
