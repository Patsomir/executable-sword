using UnityEngine;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField]
    private HealthManager source = null;

    [SerializeField]
    private Transform target = null;

    private int currentHealth;
    private int maxHealth;

    private float screenHealth;
    private float resizeThreshold = 0.1f;

    private void Start()
    {
        maxHealth = source.MaxHealth;
        currentHealth = source.Health;
        screenHealth = source.Health;
    }

    private void Update()
    {
        float delta = currentHealth - screenHealth;
        if(Mathf.Abs(delta) > resizeThreshold)
        {
            screenHealth += 4 * Time.deltaTime * (currentHealth - screenHealth);
            float xScale = 0.5f + (screenHealth / maxHealth)/2.0f;
            target.localScale = new Vector3(xScale, 1, 1);
        }
    }
    void UpdateHealthMeter(int damage)
    {
        currentHealth = source.Health;
    }

    private void OnEnable()
    {
        source.OnTakeDamage += UpdateHealthMeter;
    }

    private void OnDisable()
    {
        source.OnTakeDamage -= UpdateHealthMeter;
    }
}
