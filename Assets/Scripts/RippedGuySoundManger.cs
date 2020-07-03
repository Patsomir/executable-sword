using UnityEngine;

public class RippedGuySoundManger : MonoBehaviour
{
    private VFXEvaporation evaporator = null;

    private void Awake()
    {
        evaporator = transform.root.GetComponentInChildren<VFXEvaporation>();
    }

    private void PlayBurstSound()
    {
        SoundManager.Explode();
    }

    private void OnEnable()
    {
        evaporator.OnBurst += PlayBurstSound;
    }

    private void OnDisable()
    {
        evaporator.OnBurst -= PlayBurstSound;
    }
}
