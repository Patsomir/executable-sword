using UnityEngine;

public class RippedGuyAnimatorManager : MonoBehaviour
{
    Animator animator = null;
    HealthManager health = null;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        health = GetComponent<HealthManager>();
    }

    void SetDeathTrigger()
    {
        animator.SetTrigger("ShouldDie");
    }

    private void OnEnable()
    {
        health.OnDeath += SetDeathTrigger;
    }

    private void OnDisable()
    {
        health.OnDeath -= SetDeathTrigger;
    }
}
