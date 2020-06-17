using UnityEngine;

public class DamageDetector : MonoBehaviour
{
    [SerializeField]
    private HealthManager health = null;

    [SerializeField]
    [Range(0, 100)]
    private int penetrationRes = 0;

    [SerializeField]
    [Range(-100, 100)]
    private int cutRes = 0;

    [SerializeField]
    [Range(-100, 100)]
    private int bluntRes = 0;

    [SerializeField]
    [Range(-100, 100)]
    private int fireRes = 0;

    [SerializeField]
    [Range(-100, 100)]
    private int iceRes = 0;

    [SerializeField]
    [Range(-100, 100)]
    private int lightningRes = 0;

    public int PenetrationRes
    {
        get { return penetrationRes; }
        private set { penetrationRes = value; }
    }
    public int CutRes
    {
        get { return cutRes; }
        private set { cutRes = value; }
    }
    public int Blunt
    {
        get { return bluntRes; }
        private set { bluntRes = value; }
    }
    public int Fire
    {
        get { return fireRes; }
        private set { fireRes = value; }
    }
    public int Ice
    {
        get { return iceRes; }
        private set { iceRes = value; }
    }
    public int Lightning
    {
        get { return lightningRes; }
        private set { lightningRes = value; }
    }

    void Start()
    {
        if(health == null)
        {
            health = transform.root.GetComponent<HealthManager>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("DamageSource"))
        {
            collision.transform.tag = "Untagged";
            health.takeDamage(CalculateDamage(collision.transform.GetComponent<DamageSource>()));
        }
    }

    private int CalculateDamage(DamageSource source)
    {
        int physicalDamage = source.Blunt * (100 - bluntRes);
        if(penetrationRes < source.Penetration)
        {
            physicalDamage += source.Cut * (100 - cutRes);
        }
        int elementalDamage = source.Fire * (100 - fireRes) + 
                              source.Ice * (100 - iceRes) + 
                              source.Lightning * (100 - lightningRes);

        return (physicalDamage + elementalDamage) / 100;
    }
}
