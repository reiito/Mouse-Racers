using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuBig : StateMachineBehaviour
{
    UIManager ui;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ui = UIManager.uiManagerInstance;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ui.StartMenuAnimHalf();
    }
}
