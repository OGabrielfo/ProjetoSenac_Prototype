using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public int jumpLimit;
    public float ClimbSpeed = 3f;
    public float SwimSpeed = 5f;
    public float empuxo = 5f;
    public float flutuacao = 10f;
    public Transform groundCheck;
    public LayerMask ground;
    public GameObject AttackCol;
    public LayerMask wall;
    public Transform wallCheck;
    public LayerMask water;
    public Transform waterCheck;

    private Rigidbody _rigidbody;
    private Vector3 _movement;
    private Animator _anim;

    private bool _faceRight = true;
    private int _jumpCounter;
    private bool _isTatuTransform = false;
    private bool _isAttacking = false;
    private bool _isClimbing;
    private bool _isSwiming;



    // Start is called before the first frame update

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        if (!_isAttacking) {
            PlayerMove();
        }


        if (Input.GetButtonDown("Jump") && ((_jumpCounter < jumpLimit) || IsGrounded()))
        {
            Jump();
        }

        if (IsGrounded())
        {
            _jumpCounter = 1;
        }

        if (Input.GetButtonDown("Attack") && !_isTatuTransform)
        {
            AttackOn();
        }
        if (Input.GetButtonDown("Transform"))
        {
            TatuTransform();
        }
            
        if (Physics.CheckSphere(wallCheck.position, 0.01f, wall))
        {
            _isClimbing = true;
            Climb();
        }
        else
        {
            _isClimbing = false;
        }
        if (Physics.CheckSphere(waterCheck.position, 0.01f, water))
        {
            _isSwiming = true;
            Swim();
        }
        else
        {
            _isSwiming = false;

        }

        
    }

    void LateUpdate()
    {
        _anim.SetBool("Idle", _movement == Vector3.zero);
        _anim.SetBool("isGrounded", IsGrounded());
        _anim.SetFloat("VerticalVelocity", _rigidbody.velocity.y);
        _anim.SetBool("Transform",_isTatuTransform);
        _anim.SetBool("isClimbing", _isClimbing);
    }

    void PlayerMove()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _movement = new Vector3(horizontalInput, 0f, 0f);
        if (horizontalInput < 0f && _faceRight == true)
        {
            Flip();
        }
        else if (horizontalInput > 0f && _faceRight == false)
        {
            Flip();
        }
        float horizontalVelocity = _movement.normalized.x * speed;
        _rigidbody.velocity = new Vector3(horizontalVelocity, _rigidbody.velocity.y, _rigidbody.velocity.z);
    }

    void TatuTransform()
    {
        if (_isTatuTransform == false)
        {
            GetComponent<SphereCollider>().enabled = true;
            GetComponent<CapsuleCollider>().enabled = false;
            _isTatuTransform = true;
        } else
        {
            GetComponent<CapsuleCollider>().enabled = true;
            GetComponent<SphereCollider>().enabled = false;
            _isTatuTransform = false;
        }
    }

    void Climb()
    {
        float VerticalInput = Input.GetAxisRaw("Vertical");
        _movement = new Vector3(0f, VerticalInput, 0f);

        float verticalvelocity = _movement.normalized.y * ClimbSpeed;

        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, verticalvelocity, _rigidbody.velocity.z);
    }

    void Swim()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float VerticalInput = Input.GetAxisRaw("Vertical");
        _movement = new Vector3(horizontalInput, VerticalInput, 0f);


        _rigidbody.velocity = _movement * SwimSpeed;


        bool acimaDaAgua = transform.position.y > 0;


        if (acimaDaAgua)
        {
            Vector3 forcaFlutuacao = Vector3.up * flutuacao;
            _rigidbody.AddForce(forcaFlutuacao, ForceMode.Force);
        }


        if (!acimaDaAgua)
        {
            Vector3 forcaEmpuxo = Vector3.down * empuxo;
            _rigidbody.AddForce(forcaEmpuxo, ForceMode.Force);
        }


    }



    void Jump()
    {
        _rigidbody.velocity = new Vector3(0f, 0f, 0f);
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        _anim.SetTrigger("Jump");
        _jumpCounter++;
    }

    void Flip()
    {
        _faceRight = !_faceRight;

        if (_faceRight)
        {
            transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        else
        {
            transform.localRotation = new Quaternion(0f, 180f, 0f, 0f);
        }

    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.01f, ground);
    }

    void AttackOn()
    {
        _rigidbody.velocity = Vector3.zero;
        _anim.SetTrigger("Attack");
        AttackCol.SetActive(true);
        _isAttacking = true;
    }

    void AttackOff()
    {
        AttackCol.SetActive(false);
        _isAttacking = false;
    }


}
