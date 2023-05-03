using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waiting : StateMachineBehaviour
{
    
    public float minTime;
    public float maxTime;

    private float timer;
    private float timerFaseDois;
    private float _vidaAtual;
    private float _vidaMax;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
        _vidaAtual = animator.GetFloat("VidaAtual");
        _vidaMax = animator.GetFloat("VidaTotal");
        timerFaseDois = timer / 3;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_vidaAtual <= _vidaMax / 2)
        {
            if (timerFaseDois <= 0)
            {
                animator.SetBool("Idle", false);
            }
            else
            {
                timerFaseDois -= Time.deltaTime;
            }
        }
        else
        {
            if (timer <= 0)
            {
                animator.SetBool("Idle", false);
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
            
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
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
