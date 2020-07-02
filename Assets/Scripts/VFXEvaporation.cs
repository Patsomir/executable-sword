using System.Collections;
using UnityEngine;

public class VFXEvaporation : MonoBehaviour
{
    HealthManager health;
    SpriteRenderer sprite;
    ParticleSystem[] particles;
    Transform root = null;

    [SerializeField]
    private bool subscribeToDeath = true;

    [SerializeField]
    [Range(0, 1)]
    private float darkeningIntensity = 0.5f;

    [SerializeField]
    private float darkeningDuration = 0.5f;

    [SerializeField]
    private float darkeningTimeOffset = 1.0f;

    [SerializeField]
    private int emissionRate = 8;

    [SerializeField]
    private int burstRate = 50;

    void Start()
    {
        sprite = root.GetComponent<SpriteRenderer>();
        particles = GetComponentsInChildren<ParticleSystem>();
        foreach(ParticleSystem i in particles)
        {
            i.Stop();
        }
        ParticleSystem.EmissionModule emission = particles[0].emission;
        emission.rateOverTime = emissionRate / 2;
        emission = particles[1].emission;
        emission.rateOverTime = emissionRate / 2;
    }

    private void Awake()
    {
        root = transform.root;
        if (subscribeToDeath)
        {
            health = root.GetComponent<HealthManager>();
        }
    }

    public void Evaporate()
    {
        StartCoroutine(EvaporateCoroutine());
    }

    private IEnumerator EvaporateCoroutine()
    {
        yield return new WaitForSeconds(darkeningTimeOffset);

        particles[0].Play();
        particles[1].Play();

        float color = 0.0f;
        float alpha;
        float normalizedTime;
        float timestamp = Time.time + darkeningDuration;

        while (Time.time < timestamp)
        {
            normalizedTime = 1 - (timestamp - Time.time) / darkeningDuration;
            color = 1 - darkeningIntensity * normalizedTime;
            alpha = 1 - normalizedTime/4;
            sprite.color = new Color(color, color, color, alpha);
            yield return null;
        }
        //sprite.color = new Color(color, color, color, 0);
        sprite.enabled = false;
        root.GetComponent<Rigidbody2D>().simulated = false;

        particles[0].Stop();
        particles[1].Stop();
        particles[2].Emit(burstRate / 2);
        particles[3].Emit(burstRate / 2);

        yield return new WaitForSeconds(10);

        Destroy(root.gameObject);
    }

    private void OnEnable()
    {
        if (subscribeToDeath)
        {
            health.OnDeath += Evaporate;
        }
    }

    private void OnDisable()
    {
        if (subscribeToDeath)
        {
            health.OnDeath -= Evaporate;
        }
    }

}
