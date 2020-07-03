using UnityEngine;

public class UIAmmo : MonoBehaviour
{
    [SerializeField]
    private UINumberBox currentSwords = null;

    [SerializeField]
    private UINumberBox maxSwords = null;

    [SerializeField]
    private Shooter source = null;

    private int lastCurrentAmmo = -1;
    private bool shouldInitializeMaxSwords = true;

    void Start()
    {
        UpdateCurrentSwordsUI();
        UpdateMaxSwordsUI();
    }

    void Update()
    {
        UpdateCurrentSwordsUI();
        if (shouldInitializeMaxSwords)
        {
            UpdateMaxSwordsUI();
            shouldInitializeMaxSwords = false;
        }
    }

    private void UpdateCurrentSwordsUI()
    {
        int currentAmmo = source.GetCurrentWeaponAmmo();
        if (lastCurrentAmmo != currentAmmo)
        {
            currentSwords.SetNumber(currentAmmo);
            lastCurrentAmmo = currentAmmo;
        }
    }

    private void UpdateMaxSwordsUI()
    {
        maxSwords.SetNumber(source.GetCurrentWeaponCapacity());
    }

    private void OnEnable()
    {
        source.OnWeaponChange += UpdateMaxSwordsUI;
    }

    private void OnDisable()
    {
        source.OnWeaponChange -= UpdateMaxSwordsUI;
    }
}
