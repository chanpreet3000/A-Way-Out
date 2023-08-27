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
        playerInput = GetMovementInput();
        isGrounded = CheckIfGrounded();
        ApplyTorque();
        Jump();
    }

    private bool IsJumpInput()
    {
        bool b = Input.GetKey(KeyCode.Space);
        foreach (Touch item in Input.touches)
            b |= item.position.x >= Screen.width / 2;
        return b;
    }

    private bool CheckIfGrounded()
    {
        Vector3 groundCheckTransform = transform.position + new Vector3(0, -transform.localScale.y / 2 - 0.06f, 0);
        return Physics.CheckSphere(groundCheckTransform, 0.05f);
    }

    private void ApplyTorque()
    {
        rb.AddTorque(new Vector3(0, 0, playerInput.x * torqueMultipler * Time.deltaTime * -1));
    }

    private Vector3 GetMovementInput()
    {
        return new Vector3(joystick.Horizontal + Input.GetAxis("Horizontal"),
         joystick.Vertical + Input.GetAxis("Vertical"), 0);
    }

    public void Jump()
    {
        if (!isGrounded || !IsJumpInput()) return;
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }
}