using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{
    private HingeJoint _hingeJoint;
    private Rigidbody _playerRigidbody;

    private bool _isSwinging = false;

    private void Start()
    {
        _hingeJoint = GetComponentInChildren<HingeJoint>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerRigidbody = other.GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerRigidbody = null;
        }
    }

    private void Update()
    {
        if (_playerRigidbody != null && Input.GetKeyDown(KeyCode.Space))
        {
            if (!_isSwinging)
            {
                _hingeJoint.connectedBody = _playerRigidbody;
                _isSwinging = true;
            }
            else
            {
                _hingeJoint.connectedBody = null;
                _isSwinging = false;
                _playerRigidbody.AddForce(Vector3.up * 10f, ForceMode.Impulse);
            }
        }
    }
}
