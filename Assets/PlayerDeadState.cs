using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : StateMachineBehaviour
{

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Rigidbody2D body = animator.GetComponent<Rigidbody2D>();
        body.freezeRotation = false;
        body.sharedMaterial = null;
    }
}
