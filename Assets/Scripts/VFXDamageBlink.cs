using System.Collections;
using UnityEngine;

public class VFXDamageBlink : MonoBehaviour
{
    HealthManager health = null;
    SpriteRenderer sprite = null;

    [SerializeField]
    private int fullBlinkThreshold = 50;

    [SerializeField]
    private float blinkTime = 0.1f;

    void Start()
    {
        sprite = transform.root.GetComponent<SpriteRenderer>();
    }

    private void Awake()
    {
        health = transform.root.GetComponent<HealthManager>();
    }

    public void Blink(int damage)
    {
        StopAllCoroutines();
        StartCoroutine(BlinkCoroutine((float) damage / fullBlinkThreshold));
    }

    private IEnumerator BlinkCoroutine(float intensity)
    {
        float color = 1 - intensity;
        sprite.color = new Color(color, color, color);
        float timestamp = Time.time + blinkTime;

        while(Time.time < timestamp)
        {
            color = 1 - intensity * (timestamp - Time.time) / blinkTime;
            sprite.color = new Color(color, color, color);
            yield return null;
        }

        sprite.color = Color.white;
    }

    private void OnEnable()
    {
        health.OnTakeDamage += Blink;
    }

    private void OnDisable()
    {
        health.OnTakeDamage -= Blink;
    }
}
