using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController chController;
    [SerializeField] float speed = 50f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float sphereRadius = 0.3f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float jumpHeight = 3f;
    [SerializeField] float gravity = -50f;
    [SerializeField] GameObject maxLeft;
    [SerializeField] GameObject maxRight;

    private Vector3 velocity;
    private bool enabledFreeMovement;

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnPlayerTimeElapsed += EnablePlayerFreeMovement;
        }
    }

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
        float valueEjeX = Input.GetAxis("Vertical");

        if (!enabledFreeMovement)
        {
            return transform.forward * valueEjeZ;
        }
        else
        {
            return transform.forward * valueEjeZ + transform.right * -valueEjeX;
        }
        
    }
    private bool CheckPlayerIsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);
    }

    private void EnablePlayerFreeMovement()
    {
        enabledFreeMovement = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
    }
}
