using UnityEngine;

public class SwordSoundManager : MonoBehaviour
{
    private SwordCollisionReaction collision = null;
    private bool alreadyBounced = false;

    private void Awake()
    {
        collision = transform.root.GetComponent<SwordCollisionReaction>();
    }

    private void PlayPierceSound()
    {
        SoundManager.Stab();
    }

    private void PlayBounceSound()
    {
        if (!alreadyBounced)
        {
            SoundManager.Bounce();
            alreadyBounced = true;
        }
    }

    private void OnEnable()
    {
        collision.OnPierce += PlayPierceSound;
        collision.OnBounce += PlayBounceSound;
    }

    private void OnDisable()
    {
        collision.OnPierce -= PlayPierceSound;
        collision.OnBounce -= PlayBounceSound;
    }
}
