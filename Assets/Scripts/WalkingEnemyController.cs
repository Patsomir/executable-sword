using UnityEngine;

public class WalkingEnemyController : MonoBehaviour
{
    private Rigidbody2D body = null;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void MoveForward(float impulse)
    {
        body.AddForce(new Vector2(Mathf.Sign(transform.localScale.x), 0) * impulse,
                      ForceMode2D.Impulse);
    }

    public void Stop()
    {
        body.velocity = new Vector2(0, body.velocity.y);
    }
}
