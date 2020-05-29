using UnityEngine;

public class SwordMovement : MonoBehaviour
{
    [SerializeField]
    private float launchForce = 10;

    [SerializeField]
    private float lifetime = 2;

    private float endLifeTimestamp;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * launchForce, ForceMode2D.Impulse);
        endLifeTimestamp = Time.time + lifetime;
    }

    void Update()
    {
        if(Time.time > endLifeTimestamp)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
