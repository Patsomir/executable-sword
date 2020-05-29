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

    private Camera cam = null;
    private Vector3 actualPosition;

    void Start()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        cam = GetComponent<Camera>();
        cam.orthographicSize = distance;
        actualPosition = transform.position;
    }

    void Update()
    {
        Vector3 cursorPosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                                       Input.mousePosition.y,
                                                                       cam.nearClipPlane));
        cursorPosition.z = 0;
        Vector3 finalOffset = (cursorPosition - target.position) * targetToCursorRate;
        finalOffset.z = -10;
        actualPosition = target.position + finalOffset;
    }

    private void FixedUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        Vector3 movementVector = actualPosition - transform.position;
        float distance = cameraSpeed * Time.fixedDeltaTime;
        movementVector = movementVector * distance;
        transform.Translate(movementVector);
    }
}
