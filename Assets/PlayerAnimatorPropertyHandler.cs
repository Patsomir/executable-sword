using UnityEngine;

public class PlayerAnimatorPropertyHandler : MonoBehaviour
{
    private Animator animator = null;
    private Rigidbody2D body = null;
    private MovementController controller = null;
    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        controller = GetComponent<MovementController>();
    }

    void Update()
    {
        animator.SetFloat("NormalizedSpeed", Mathf.Abs(body.velocity.x) / controller.MaxRunningSpeed);
        animator.SetBool("IsFalling", body.velocity.y < 0);
    }

    void TriggerJumpAnimation()
    {
        animator.SetTrigger("Jump");
    }

    private void OnEnable()
    {
        controller.OnJumpStart += TriggerJumpAnimation;
    }

    private void OnDisable()
    {
        controller.OnJumpStart -= TriggerJumpAnimation;
    }
}
