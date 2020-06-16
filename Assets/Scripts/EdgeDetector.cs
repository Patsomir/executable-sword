using UnityEngine;

public class EdgeDetector : MonoBehaviour
{
    private OrientationHandler orientation = null;
    private void Start()
    {
        orientation = transform.parent.GetComponent<OrientationHandler>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Debug.Log("EDGE");
            orientation.Flip();
        }
    }
}
