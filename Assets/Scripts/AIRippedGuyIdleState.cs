using UnityEngine;

public class AIRippedGuyIdleState : StateMachineBehaviour
{
    [SerializeField]
    private float idleDuration = 1;

    private float stepTimestamp;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stepTimestamp = Time.time + idleDuration;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(stepTimestamp < Time.time)
        {
            animator.SetTrigger("ShouldStep");
        }
    }
}
