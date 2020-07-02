using UnityEngine;

public class ShooterAnimatorManager : MonoBehaviour
{
    private Animator animator = null;
    private Shooter shooter = null;
    private HealthManager health = null;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthManager>();
    }

    public void TriggerShoot()
    {
        animator.SetTrigger("Shoot");
    }

    public void TriggerDisappear()
    {
        animator.SetTrigger("Disappear");
    }

    private void OnEnable()
    {
        shooter.OnShoot += TriggerShoot;
        if(health != null)
        {
            health.OnDeath += TriggerDisappear;
        }
    }

    private void OnDisable()
    {
        shooter.OnShoot -= TriggerShoot;
        if (health != null)
        {
            health.OnDeath -= TriggerDisappear;
        }
    }
}
