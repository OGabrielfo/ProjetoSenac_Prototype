using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : StateMachineBehaviour
{
    public float speed;
    public float minDistance;
    
    private Transform _playerPos;


     //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

     //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Seguir Player
        Vector3 targetPosition = new Vector3(_playerPos.position.x, animator.transform.position.y, _playerPos.position.z);
        animator.transform.position = Vector3.Lerp(animator.transform.position, targetPosition, Time.deltaTime * speed);
        float distanciaDoPlayer = Vector3.Distance(_playerPos.position, animator.transform.position);

        //Flipar a imagem do boss
        if (_playerPos.position.x > animator.transform.position.x)
        {
            animator.transform.localRotation = new Quaternion(0f, 180f, 0f, 0f);
        } else
        {
            animator.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
        }


        //Executar Ataque ao chegar próximo do player
        if (distanciaDoPlayer <= minDistance)
        {
            animator.SetTrigger("Attack");
        }
    }

     //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

     //OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that processes and affects root motion
    }

     //OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that sets up animation IK (inverse kinematics)
    }
}
