using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : StateMachineBehaviour
{
    private Rigidbody _rigidbody;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rigidbody = animator.GetComponent<Rigidbody>();
        Vector3 knockback = new Vector3(3f, 0f, 0f);

        if (animator.transform.localRotation.y == 0)
        {
            _rigidbody.AddForce(knockback, ForceMode.Impulse);
        }
        else
        {
            _rigidbody.AddForce(knockback * -1, ForceMode.Impulse);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rigidbody.velocity = Vector3.zero;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that sets up animation IK (inverse kinematics)
    }
}
