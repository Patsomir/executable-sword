using UnityEngine;

public class SFXPortal : MonoBehaviour
{
    private Portal portal = null;
    private void Awake()
    {
        portal = GetComponent<Portal>();
    }
    private void PlaySound()
    {
        SoundManager.ExplodeLoud();
    }

    private void OnEnable()
    {
        portal.OnActivation += PlaySound;
    }

    private void OnDisable()
    {
        portal.OnActivation -= PlaySound;
    }
}
