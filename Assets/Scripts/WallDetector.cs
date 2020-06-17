using UnityEngine;

public class WallDetector : MonoBehaviour
{
    private OrientationHandler orientation = null;
    private void Start()
    {
        orientation = transform.parent.GetComponent<OrientationHandler>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            orientation.Flip();
        }
    }
}
