using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource stab = null;

    [SerializeField]
    private AudioSource bounce = null;

    [SerializeField]
    private AudioSource throwing = null;

    [SerializeField]
    private AudioSource blunt = null;

    [SerializeField]
    private AudioSource jump = null;

    [SerializeField]
    private AudioSource damage = null;

    [SerializeField]
    private AudioSource explosion = null;


    private static SoundManager instance = null;

    void Start()
    {
        instance = this;
    }

    public static void Stab()
    {
        instance.stab.Play();
    }

    public static void Bounce()
    {
        instance.bounce.Play();
    }

    public static void Throw()
    {
        instance.throwing.Play();
    }

    public static void Blunt()
    {
        instance.blunt.Play();
    }

    public static void Jump()
    {
        instance.jump.Play();
    }

    public static void Damage()
    {
        instance.damage.Play();
    }

    public static void Explode()
    {
        instance.explosion.Play();
    }
}
