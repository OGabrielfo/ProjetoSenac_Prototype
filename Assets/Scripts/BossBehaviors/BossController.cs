using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BossFirstBehavior : MonoBehaviour
{
    public float vida;
    public float vidaMax;
    public Image vidaUI;
    public GameObject bossActivator;
    public GameObject vidaBoss;
    public GameObject attackCol;


    private Rigidbody _rigidbody;
    private Animator _anim;
    private bool _attack = false;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        vida = vidaMax;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void LateUpdate()
    {
        _anim.SetBool("Dead", vida <= 0);

        vidaUI.rectTransform.localScale = new Vector3(1.65f * (vida / vidaMax), vidaUI.rectTransform.localScale.y, vidaUI.rectTransform.localScale.z);
    }
    

    public void TakeDamage(float damage)
    {
        _rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
        vida -= damage;
    }

    public void Dead()
    {
        Destroy(gameObject);
        vidaBoss.SetActive(false);
        bossActivator.SetActive(false);
    }

    void TriggerAttack()
    {
        if (_attack)
        {
            _attack = false;
            attackCol.SetActive(false);
        } else
        {
            _attack = true;
            attackCol.SetActive(true);
        }
    }
}
