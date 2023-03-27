using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController chController;
    [SerializeField] float speed = 10f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float sphereRadius = 0.3f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float jumpHeight = 3f;
    [SerializeField] float gravity = -9.8f;
    [SerializeField] GameObject maxLeft;
    [SerializeField] GameObject maxRight;

    private Vector3 velocity; 

    void Update()
    {
        ImplementationOfPlayerMovementAndJump();
    }
    private void ImplementationOfPlayerMovementAndJump()
    {
        AdjustVelocityOnGrounded();
        chController.Move(MovementInTheZAxis() * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && CheckPlayerIsGrounded())
        {
            velocity.y = GetJumpVelocity();
        }

        velocity.y += gravity * Time.deltaTime;
        chController.Move(velocity * Time.deltaTime);
    }

    private void AdjustVelocityOnGrounded()
    {
        const float groundFallSpeed = -2f;
        if (CheckPlayerIsGrounded() && velocity.y < 0)
        {
            velocity.y = groundFallSpeed;
        }
    }
    private float GetJumpVelocity()
    {
       return Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    private Vector3 MovementInTheZAxis()
    {
        float valueEjeZ = Input.GetAxis("Horizontal");
        return transform.forward * valueEjeZ;
    }
    private bool CheckPlayerIsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);
    }
}
