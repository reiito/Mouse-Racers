using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenuOut : StateMachineBehaviour
{
    AnimationStateMachine asm;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        asm = AnimationStateMachine.animationStateMachineInstance;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        asm.EndMenuEnd();
    }
}
