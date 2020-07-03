using UnityEngine;

public class ShooterSoundManager : MonoBehaviour
{
    private Shooter shooter = null;

    private void Awake()
    {
        shooter = transform.root.GetComponent<Shooter>();
    }

    private void PlayThrowingSound()
    {
        SoundManager.Throw();
    }

    private void OnEnable()
    {
        shooter.OnShoot += PlayThrowingSound;
    }

    private void OnDisable()
    {
        shooter.OnShoot -= PlayThrowingSound;
    }
}
