using UnityEngine;
using UnityEngine.UIElements;

public class ShooterMovement : MonoBehaviour
{
    [SerializeField]
    private float radius = 5;

    [SerializeField]
    private Vector3 offset = new Vector3(1, 0, 0);

    [SerializeField]
    private Transform center = null;
    private void Start()
    {
        if(center == null)
        {
            center = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    public void PointAt(Vector3 target)
    {
        Vector3 centerPosition = center.position + offset;

        target.z = centerPosition.z;
        Vector3 direction = target - centerPosition;
        direction.z = 0;
        direction = direction.normalized * radius;
        transform.position = centerPosition + direction;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

}
