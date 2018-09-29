﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStateBehaviour : StateMachineBehaviour
{
  AnimationManager animationManager;

  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    animationManager = AnimationManager.animationStateMachineInstance;
  }

  override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    animationManager.EndMenuBackHalf();
  }
}
