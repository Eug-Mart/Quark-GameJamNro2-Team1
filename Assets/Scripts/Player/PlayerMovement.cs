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
        InitializesMovement();
    }

    public void InitializesMovement()
    {
        if (IsGounded() && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        chController.Move(DefinitionOfDirectionAndMovement() * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && IsGounded())
        {
            Jump();
        }

        velocity.y += gravity * Time.deltaTime;
        chController.Move(velocity * Time.deltaTime);
    }


    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    private Vector3 DefinitionOfDirectionAndMovement()
    {
        float valueOfTheVirtualAxisZ  = Input.GetAxis("Horizontal");
        return transform.forward * valueOfTheVirtualAxisZ;
    }
    private bool IsGounded()
    {
        return  Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);
    }

   
}
