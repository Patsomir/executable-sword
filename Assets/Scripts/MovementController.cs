using System;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float acceleration = 100;

    [SerializeField]
    private float jumpForce = 1000;

    [SerializeField]
    private float walkSlowdownRate = 2;

    [SerializeField]
    private float jumpDuration = 1;

    [SerializeField]
    private float maxWalkingSpeed = 20;

    public float MaxWalkingSpeed
    {
        get { return maxWalkingSpeed; }
        private set { maxWalkingSpeed = value; }
    }

    [SerializeField]
    private float maxRunningSpeed = 40;

    public float MaxRunningSpeed
    {
        get { return maxRunningSpeed; }
        private set { maxRunningSpeed = value; }
    }

    private float zeroFloatThreshold = 0.001f;

    private float currentMaxSpeed;
    private float currentJumpMultiplier = 0;
    private float horizontalVelocity = 0;
    private float verticalVelocity = 0;

    private float jumpEndTimestamp;

    private Vector2 movementForce;
    private Rigidbody2D body = null;

    private bool onGround = false;

    public Action OnJumpStart;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        currentMaxSpeed = maxWalkingSpeed;
    }

    private void FixedUpdate()
    {
        CalculateMovementForces();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            onGround = false;
        }
    }

    public bool CanJump()
    {
        return onGround;
    }

    public bool CanMove(float direction)
    {
        float currentVelocity = body.velocity.x;
        return Mathf.Abs(currentVelocity) < currentMaxSpeed ||
               currentVelocity * direction < 0;
    }

    public void Move(float direction)
    {
        if(Mathf.Abs(direction) > zeroFloatThreshold && CanMove(direction))
        {
            horizontalVelocity = Mathf.Sign(direction) * acceleration;
        } else
        {
            horizontalVelocity = 0;
        }
    }

    public void Jump()
    {
        if (CanJump())
        {
            verticalVelocity = jumpForce;
            jumpEndTimestamp = Time.time + jumpDuration;
            OnJumpStart?.Invoke();
        }
    }

    public void TerminateJump()
    {
        verticalVelocity = 0;
    }

    public void StartRunning()
    {
        currentMaxSpeed = maxRunningSpeed;
    }

    public void StopRunning()
    {
        currentMaxSpeed = maxWalkingSpeed;
    }

    private void CalculateMovementForces()
    {
        if (verticalVelocity > 0)
        {
            verticalVelocity = jumpForce * Mathf.Pow((jumpEndTimestamp - Time.time) / jumpDuration, 5);
        } else
        {
            verticalVelocity = 0;
        }
        if (Mathf.Abs(horizontalVelocity) < zeroFloatThreshold)
        {
            body.velocity = new Vector2(body.velocity.x / walkSlowdownRate, body.velocity.y);
        }
        movementForce.Set(horizontalVelocity , verticalVelocity);
        body.AddForce(movementForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }
}
