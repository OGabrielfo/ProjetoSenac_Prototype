using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycontroller : MonoBehaviour
{

    public float velocidade;
    public float saude = 100f;
    public float dano = 10f;
    public float distanciaDoPlayer;
    public float distanciaMaxima;
    public float veloci = 5f;
    
    private Animator _anim;
    public Rigidbody _rigidbody;
    public bool idle = true;
    private GameObject _player;
    private float _velocity;
    public bool patrulha = true;
    private Patroller Patrulha;
    private Transform jogador;


    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
        _anim = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _player = GameObject.FindWithTag("Player");
        Patrulha = GetComponent<Patroller>();

    }


    void Update()
    {
        distanciaDoPlayer = Vector3.Distance(_player.transform.position, transform.position);

        if(distanciaDoPlayer <= distanciaMaxima)
        {
            patrulha = false;
            Patrulha.enabled = false;
        } else
        {
            patrulha = true;
            Patrulha.enabled = true;
        }

        if (patrulha == false)
        {
            Vector3 direction = (jogador.position - transform.position).normalized;
            _rigidbody.MovePosition(transform.position + direction * velocidade * Time.fixedDeltaTime);

        }

        if (_rigidbody.velocity != Vector3.zero)
        {
            idle = false;
        }
        else
        {
            idle = true;
        }
        _anim.SetBool("idle", idle);

    }
    public void ReceberDano(float quantidade)
    {
        _rigidbody = GetComponent<Rigidbody>();
        Vector3 knockback = new Vector3(3f, 0f, 0f);

        if (transform.localRotation.y == 0)
        {
            _rigidbody.AddForce(knockback, ForceMode.Impulse);
        }
        else
        {
            _rigidbody.AddForce(knockback * -1, ForceMode.Impulse);
        }
        saude -= quantidade;
        _anim.SetTrigger("Hit");



        if (saude <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision colisao)
    {
        if (colisao.gameObject.CompareTag("Player"))
        {
            PlayerController jogador = colisao.gameObject.GetComponent<PlayerController>();
            jogador.ReceberDano(dano);
        }
    }
    private void FixedUpdate()
    {
        // calcula a direção do player em relação ao inimigo
        Vector3 direction = (jogador.position - transform.position).normalized;

        // flipa a sprite do inimigo na direção do movimento
        if (direction.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (direction.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}


