using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSwing : MonoBehaviour
{
    /*private bool _isHanging = false;
    private HingeJoint _hingeJoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RopeSegment") && !_isHanging)
        {
            _isHanging = true;
            _hingeJoint = gameObject.AddComponent<HingeJoint>();
            _hingeJoint.connectedBody = other.attachedRigidbody;
            _hingeJoint.autoConfigureConnectedAnchor = false;
            _hingeJoint.anchor = Vector3.zero;
            _hingeJoint.connectedAnchor = other.ClosestPoint(transform.position);
            Debug.Log("Colidiu");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_isHanging)
        {
            float inputVertical = Input.GetAxisRaw("Vertical");
            float inputHorizontal = Input.GetAxisRaw("Horizontal");

            if (inputVertical > 0f)
            {
                _hingeJoint.connectedAnchor += Vector3.up * 0.1f;
            }
            else if (inputVertical < 0f)
            {
                _hingeJoint.connectedAnchor += Vector3.down * 0.1f;
            }

            if (inputHorizontal > 0f)
            {
                _hingeJoint.connectedAnchor += Vector3.right * 0.1f;
            }
            else if (inputHorizontal < 0f)
            {
                _hingeJoint.connectedAnchor += Vector3.left * 0.1f;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isHanging = false;
                Destroy(_hingeJoint);
                GetComponent<Rigidbody>().AddForce(Vector3.up * 10f, ForceMode.Impulse);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_isHanging && other.CompareTag("RopeSegment"))
        {
            _isHanging = false;
            Destroy(_hingeJoint);
        }
    }*/
}
