using UnityEngine;

public class AIRippedGuyDeadState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Rigidbody2D>().freezeRotation = false;
        animator.transform.Translate(1.5f * Vector2.up, Space.Self);
    }
}
