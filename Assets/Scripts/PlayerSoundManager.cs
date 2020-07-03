using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    private MovementController controller = null;
    private HealthManager health = null;
    private VFXEvaporation evaporator = null;

    private void Awake()
    {
        controller = transform.root.GetComponent<MovementController>();
        health = transform.root.GetComponent<HealthManager>();
        evaporator = transform.root.GetComponentInChildren<VFXEvaporation>();
    }

    private void PlayJumpSound()
    {
        SoundManager.Jump();
    }

    private void PlayDamageSound(int damage)
    {
        if (!health.IsDead())
        {
            SoundManager.Damage();
        }
    }

    private void PlayDeathSound()
    {
        SoundManager.DamageLoud();
    }

    private void PlayBurstSound()
    {
        SoundManager.Explode();
    }

    private void OnEnable()
    {
        controller.OnJumpStart += PlayJumpSound;
        health.OnDeath += PlayDeathSound;
        health.OnTakeDamage += PlayDamageSound;
        evaporator.OnBurst += PlayBurstSound;
    }

    private void OnDisable()
    {
        controller.OnJumpStart -= PlayJumpSound;
        health.OnDeath -= PlayDeathSound;
        health.OnTakeDamage -= PlayDamageSound;
        evaporator.OnBurst -= PlayBurstSound;
    }
}
