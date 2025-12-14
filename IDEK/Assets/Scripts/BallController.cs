using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    private PlayerInput input;
    private Rigidbody rb;

    private Vector2 inputMovement;
    private Vector3 direction;

    private Vector3 respawn;

    private bool isGround = true;

    [Header("Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    RaycastHit hit;

    void Start()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();

        respawn = transform.position;
    }

    void Update()
    {
        inputMovement = input.actions["Move"].ReadValue<Vector2>();
        direction.x = inputMovement.x;
        direction.z = inputMovement.y;

        Die();
    }

    private void FixedUpdate()
    {
        if (isGround)
        {
            rb.AddForce(direction * speed, ForceMode.Impulse);
        }
        
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.6f))
            isGround = true;
        else
            isGround = false;
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && isGround)
        {
            float cancelY = -rb.linearVelocity.y;
            rb.AddForce(new Vector3(0, cancelY, 0), ForceMode.VelocityChange);

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isGround = false;
        }
    }

    public void Die()
    {
        if (transform.position.y < 0)
        {
            transform.position = respawn;
            rb.linearVelocity = Vector3.zero;
        }
    }
}