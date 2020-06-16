using UnityEngine;

public class OrientationHandler : MonoBehaviour
{
    public void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    public void SetOrientation(float direction)
    {
        if (direction != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(direction), transform.localScale.y, transform.localScale.z);
        }
    }
}
