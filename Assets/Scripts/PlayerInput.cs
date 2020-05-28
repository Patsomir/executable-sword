using UnityEngine;
using static Controls;

public class PlayerInput : MonoBehaviour
{
    private MovementController controller = null;

    private void Start()
    {
        controller = GetComponent<MovementController>();
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
    }
}
