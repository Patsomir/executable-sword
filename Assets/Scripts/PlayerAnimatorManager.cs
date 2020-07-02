using UnityEngine;

public class PlayerAnimatorManager : MonoBehaviour
{
    private Animator animator = null;
    private Rigidbody2D body = null;
    private MovementController controller = null;
    private HealthManager health = null;

    [SerializeField]
    private float fallingThreshold = 0.1f;

    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        controller = GetComponent<MovementController>();
        health = GetComponent<HealthManager>();
    }

    void Update()
    {
        animator.SetFloat("NormalizedSpeed", Mathf.Abs(body.velocity.x) / controller.MaxRunningSpeed);
        animator.SetBool("IsFalling", body.velocity.y < fallingThreshold);
    }

    void TriggerJumpAnimation()
    {
        animator.SetTrigger("Jump");
    }

    void TriggerDeathAnimation()
    {
        animator.SetTrigger("ShouldDie");
    }

    private void OnEnable()
    {
        controller.OnJumpStart += TriggerJumpAnimation;
        health.OnDeath += TriggerDeathAnimation;
    }

    private void OnDisable()
    {
        controller.OnJumpStart -= TriggerJumpAnimation;
        health.OnDeath -= TriggerDeathAnimation;
    }
}
