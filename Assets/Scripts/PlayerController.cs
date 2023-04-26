using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public int jumpLimit;
    public Transform groundCheck;
    public LayerMask ground;
    public GameObject AttackCol;

    private Rigidbody _rigidbody;
    private Vector3 _movement;
    private Animator _anim;

    private bool _faceRight = true;
    private int _jumpCounter;
    private bool _isCrouching = false;



    // Start is called before the first frame update

    void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    void Start() {
        
    }



    // Update is called once per frame
    void Update()
    {
        if (!_isCrouching) {
            PlayerMove();
        }

        if (Input.GetButtonDown("Jump") && ((_jumpCounter < jumpLimit) || IsGrounded())) {
            Jump();
        }

        if (IsGrounded()) {
            _jumpCounter = 1;
        }

        if (Input.GetButtonDown("Attack"))
        {
            AttackOn();
        }

        if (Input.GetButtonDown("Transform"))
        {
            TatuTransform();
        }

        
    }
    
    void LateUpdate() {
        _anim.SetBool("Idle", _movement == Vector3.zero);
        _anim.SetBool("isGrounded", IsGrounded());
        _anim.SetFloat("VerticalVelocity", _rigidbody.velocity.y);
        //_anim.SetBool("isCrouching", _isCrouching);
    }

    void PlayerMove() {
        
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _movement = new Vector3(horizontalInput, 0f, 0f);
        if (horizontalInput < 0f && _faceRight == true) {
            Flip();
        } else if (horizontalInput > 0f && _faceRight == false) {
            Flip();
        }
        float horizontalVelocity = _movement.normalized.x * speed;
        _rigidbody.velocity = new Vector3 (horizontalVelocity, _rigidbody.velocity.y, _rigidbody.velocity.z);
    }

    void TatuTransform()
    {
        Debug.Log("Transformou");
    }


    void Jump() {
        _rigidbody.velocity = new Vector3(0f, 0f, 0f);
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        _anim.SetTrigger("Jump");
        _jumpCounter++;
    }

    void Flip() {
        _faceRight = !_faceRight;

        if (_faceRight) {
            transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
        } else {
            transform.localRotation = new Quaternion(0f, 180f, 0f, 0f);
        }
        
    }

    bool IsGrounded() {
        return Physics.CheckSphere(groundCheck.position, 0.01f, ground);
    }

    void AttackOn()
    {
        _anim.SetTrigger("Attack");
        AttackCol.SetActive(true);
    }

    void AttackOff()
    {
        AttackCol.SetActive(false);
        Debug.Log("Attack Off");
    }

}
