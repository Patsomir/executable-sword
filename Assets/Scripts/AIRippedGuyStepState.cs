using UnityEngine;

public class AIRippedGuyStepState : StateMachineBehaviour
{
    private WalkingEnemyController controller = null;

    [SerializeField]
    private float impulse = 300;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(controller == null)
        {
            controller = animator.GetComponent<WalkingEnemyController>();
        }
        controller.MoveForward(impulse);
    }

    public override void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        controller.Stop();
    }
}
