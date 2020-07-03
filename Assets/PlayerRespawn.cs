using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private HealthManager health = null;

    [SerializeField]
    private float respawnTime = 10;
    private void Awake()
    {
        health = GetComponent<HealthManager>();
    }

    public void GoToMainMenu()
    {
        SceneTransitionManager.ScheduleLoadScene("MainMenu", respawnTime);
    }

    private void OnEnable()
    {
        health.OnDeath += GoToMainMenu;
    }

    private void OnDisable()
    {
        health.OnDeath -= GoToMainMenu;
    }
}
