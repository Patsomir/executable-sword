using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private MovementController controller = null;
    private OrientationHandler orientation = null;

    [SerializeField]
    private GameObject shooter = null;

    private ShooterMovement shooterMovement = null;
    private Shooter shooterSpawner = null;

    private void Start()
    {
        controller = GetComponent<MovementController>();
        shooterMovement = shooter.GetComponent<ShooterMovement>();
        shooterSpawner = shooter.GetComponent<Shooter>();
        orientation = GetComponent<OrientationHandler>();
    }
    void Update()
    {
        if (Input.GetKey(Controls.runKey))
        {
            controller.StartRunning();
        } else
        {
            controller.StopRunning();
        }

        float movementInput = Input.GetAxisRaw(Controls.horizontalAxis);
        orientation.SetOrientation(movementInput);
        controller.Move(movementInput);

        if (Input.GetKeyDown(Controls.jumpKey))
        {
            controller.Jump();
        }
        if (Input.GetKeyUp(Controls.jumpKey))
        {
            controller.TerminateJump();
        }

        shooterMovement.PointAt(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                                           Input.mousePosition.y,
                                                                           Camera.main.nearClipPlane)));

        if (Input.GetKeyDown(Controls.nextSwordKey))
        {
            shooterSpawner.ScheduleNextSword();
        }
        if (Input.GetKeyDown(Controls.previousSwordKey))
        {
            shooterSpawner.SchedulePreviousSword();
        }
        if (Input.GetMouseButtonDown(Controls.shootButton))
        {
            shooterSpawner.ScheduleShoot();
        }
    }
}
