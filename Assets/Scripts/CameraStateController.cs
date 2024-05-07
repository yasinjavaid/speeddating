using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraStateController : StateMachineBehaviour
{
    private bool isEventCalled = false;

    [SerializeField] private bool isLab;
    [SerializeField] private bool isVaccination;
    [SerializeField] private bool isDance;

    public static UnityAction StateExitEventLab;
    public static UnityAction StateExitEventVaccine;
    public static UnityAction StateExitEventDance;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    //   OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isLab && stateInfo.normalizedTime <= 0.1f)
        {
            isEventCalled = false;
        }
        if (isVaccination && stateInfo.normalizedTime <= 0.1f)
        {
            isEventCalled = false;
        }
        if (isDance && stateInfo.normalizedTime <= 0.1f)
        {
            isEventCalled = false;
        }
        if (stateInfo.normalizedTime >= 0.9f && !isEventCalled)
        {
            if (isLab)
            {
                isEventCalled = true;
                StateExitEventLab?.Invoke();
            }
            else if (isVaccination)
            {
                isEventCalled = true;
                StateExitEventVaccine?.Invoke();
            }
            else if (isDance)
            {
                isEventCalled = true;
                StateExitEventDance?.Invoke();
            }
        }
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    public  void ResetCam() 
    {
        isLab = true;
        isVaccination = true;
        isDance = true;
    }
    
    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
