using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BossFirstBehavior : MonoBehaviour
{
    public float vida;
    public float vidaMax;
    public Image vidaUI;
    public GameObject bossActivator;
    public GameObject vidaBoss;
    public GameObject attackCol;
    public Color faseDois;
    public float dano;


    private Rigidbody _rigidbody;
    private Animator _anim;
    private SpriteRenderer _spriteRenderer;
    private bool _attack = false;
    private bool _isAttacking = false;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        vida = vidaMax;
        _anim.SetFloat("VidaAtual", vida);
        _anim.SetFloat("VidaTotal", vidaMax);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= vidaMax/2)
        {
            _spriteRenderer.color = faseDois;
        }
        
    }

    private void LateUpdate()
    {
        _anim.SetBool("Dead", vida <= 0);
        _anim.SetFloat("VidaAtual", vida);

        vidaUI.rectTransform.localScale = new Vector3(1.65f * (vida / vidaMax), vidaUI.rectTransform.localScale.y, vidaUI.rectTransform.localScale.z);
    }
    

    public void Dead()
    {
        Destroy(gameObject);
        vidaBoss.SetActive(false);
        bossActivator.SetActive(false);
    }

    public void ReceberDano(float dano)
    {
        if (!_isAttacking)
        {
            vida -= dano;
            _anim.SetTrigger("Hit");
        }
    }

    void TriggerAttack()
    {

        if (_attack)
        {
            _isAttacking = false;
            _attack = false;
            attackCol.SetActive(false);
        } else
        {
            _isAttacking = true;
            _attack = true;
            attackCol.SetActive(true);
        }
    }
}
