using UnityEngine;

public class SwordCollisionReaction : MonoBehaviour
{
    private DamageSource pen;

    [SerializeField]
    private float bounceImpulse = 25;

    [SerializeField]
    private float pierceDepth = 0.1f;
    void Start()
    {
        pen = GetComponent<DamageSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("DamageDetector") &&
            !collision.transform.CompareTag("Player"))
        {
            if (collision.collider.GetComponent<DamageDetector>().PenetrationRes < pen.Penetration)
            {
                Pierce(collision.collider);
            }
            else
            {
                Bounce(collision.collider);
            }
        }
        else
        {
            Bounce(null);
        }
        this.enabled = false;
    }

    public void Pierce(Collider2D into)
    {
        transform.parent = into.transform;
        GetComponent<Rigidbody2D>().simulated = false;
        transform.position += (into.transform.position - transform.position).normalized * pierceDepth;
    }

    public void Bounce(Collider2D from)
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.gravityScale = 8;
        if(from != null)
        {
            Vector2 impactForce = (transform.position - from.transform.position).normalized * bounceImpulse;
            body.AddForce(impactForce, ForceMode2D.Impulse);
        }
    }
}
