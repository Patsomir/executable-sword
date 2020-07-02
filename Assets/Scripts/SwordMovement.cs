using UnityEngine;

public class SwordMovement : MonoBehaviour
{
    [SerializeField]
    private float launchForce = 10;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * launchForce, ForceMode2D.Impulse);
    }
}
