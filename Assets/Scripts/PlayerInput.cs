using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private MovementController controller = null;

    [SerializeField]
    private GameObject shooter = null;

    private ShooterMovement shooterMovement = null;
    private Shooter shooterSpawner = null;

    private void Start()
    {
        controller = GetComponent<MovementController>();
        shooterMovement = shooter.GetComponent<ShooterMovement>();
        shooterSpawner = shooter.GetComponent<Shooter>();
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

        controller.Move(Input.GetAxisRaw(Controls.horizontalAxis));

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
