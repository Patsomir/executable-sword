using UnityEngine;

public class VFXPortal : MonoBehaviour
{
    private Portal portal = null;
    private void Awake()
    {
        portal = GetComponent<Portal>();
    }
    private void StopParticles()
    {
        foreach(ParticleSystem i in GetComponentsInChildren<ParticleSystem>())
        {
            i.Stop();
        }
    }

    private void ThankYou()
    {
        GetComponent<Animator>().SetTrigger("Finish");
    }

    private void OnEnable()
    {
        portal.OnActivation += StopParticles;
        portal.OnActivation += ThankYou;
    }

    private void OnDisable()
    {
        portal.OnActivation -= StopParticles;
        portal.OnActivation -= ThankYou;
    }
}
