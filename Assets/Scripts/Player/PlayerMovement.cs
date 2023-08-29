using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float torqueMultipler = 100f;
    [SerializeField] private float jumpForce = 1f;

    //
    private Joystick joystick;
    private Rigidbody rb;
    private bool isGrounded = false;
    private Vector3 playerInput;

    private void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (!joystick || !rb) return;
        isGrounded = CheckIfGrounded();
        playerInput = GetMovementInput();
        ApplyTorque();
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
    private bool CheckIfGrounded()
    {
        Vector3 groundCheckTransform = transform.position + new Vector3(0, -transform.localScale.y / 2 - 0.06f, 0);
        return Physics.CheckSphere(groundCheckTransform, 0.05f);
    }

    private void ApplyTorque()
    {
        rb.AddTorque(new Vector3(0, 0, playerInput.x * torqueMultipler * Time.fixedDeltaTime * -1));
    }

    private Vector3 GetMovementInput()
    {
        return new Vector3(joystick.Horizontal, 0, 0);
    }

    public void Jump()
    {
        if (!isGrounded) return;
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }
}