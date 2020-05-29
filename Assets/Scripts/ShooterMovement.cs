using UnityEngine;
using UnityEngine.UIElements;

public class ShooterMovement : MonoBehaviour
{
    [SerializeField]
    private float radius = 5;

    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    private Transform center = null;
    private void Start()
    {
        if(center == null)
        {
            center = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                                    Input.mousePosition.y,
                                                                    Camera.main.nearClipPlane));
        Vector3 centerPosition = center.position + offset;

        cursorPosition.z = centerPosition.z;
        Vector3 direction = cursorPosition - centerPosition;
        direction.z = 0;
        direction = direction.normalized * radius;
        transform.position = centerPosition + direction;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
