using UnityEngine;

public class AIRippedGuyIdleState : StateMachineBehaviour
{
    [SerializeField]
    private float idleDuration = 1;

    [SerializeField]
    private float aggroRange = 10;

    private float stepTimestamp;
    private Transform player = null;
    private VisualPerception eyes = null;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stepTimestamp = Time.time + idleDuration;
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if (eyes == null)
        {
            eyes = animator.gameObject.GetComponentInChildren<VisualPerception>();
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(stepTimestamp < Time.time)
        {
            animator.SetTrigger("ShouldStep");
        }
        else if((animator.transform.position - player.position).magnitude < aggroRange && eyes.CanSeePlayer())
        {
            animator.SetTrigger("ShouldKick");
        }
    }
}
