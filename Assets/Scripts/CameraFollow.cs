using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float distance = 12;

    [SerializeField]
    private float targetToCursorRate = 0.25f;

    [SerializeField]
    private float cameraSpeed = 5f;

    [SerializeField]
    private Vector2 horizontalBounds;

    [SerializeField]
    private Vector2 verticalBounds;

    private Camera cam = null;
    private Vector3 actualPosition;

    private void Start()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        cam = GetComponent<Camera>();
        cam.orthographicSize = distance;
        actualPosition = transform.position;
    }

    private void Update()
    {
        Vector3 cursorPosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                                       Input.mousePosition.y,
                                                                       cam.nearClipPlane));
        cursorPosition.z = 0;
        Vector3 finalOffset = (cursorPosition - target.position) * targetToCursorRate;
        finalOffset.z = -10;
        actualPosition = target.position + finalOffset;
        ResolveBounds();
    }

    private void ResolveBounds()
    {
        actualPosition.Set(Mathf.Clamp(actualPosition.x, horizontalBounds.x, horizontalBounds.y),
                           Mathf.Clamp(actualPosition.y, verticalBounds.x, verticalBounds.y),
                           actualPosition.z);
    }

    private void FixedUpdate()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        Vector3 movementVector = actualPosition - transform.position;
        float distance = cameraSpeed * Time.fixedDeltaTime;
        movementVector = movementVector * distance;
        transform.Translate(movementVector);
    }
}
