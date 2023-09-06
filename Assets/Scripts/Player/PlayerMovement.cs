using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float torqueMultipler = 100f;
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private GameObject playerDeathPrefab;

    public bool isLevelCompleted = false;
    private bool isPlayerDead = false;

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
        if (isPlayerDead || isLevelCompleted) return;
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
        AudioManager.Instance.PlayAudio(Sound.PlayerJump);
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LevelExit"))
        {
            isLevelCompleted = true;
            LevelManager.Instance.LevelCompleted();
        }
        else if (other.CompareTag("SpikeTrap"))
        {
            other.GetComponent<Animator>().SetTrigger("activate");
            PlayerDead();
        }
        else if (other.CompareTag("PressTrap"))
        {
            PlayerDead();
        }
        else if (other.CompareTag("Lava"))
        {
            PlayerDead();
        }
    }
    private void PlayerDead()
    {
        if (isPlayerDead) return;
        isPlayerDead = true;


        Debug.Log("Player Dead");
        AudioManager.Instance.PlayAudio(Sound.PlayerDead);
        Instantiate(playerDeathPrefab, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        FindObjectOfType<PlayerHUD>().OnPlayerDead();
        Invoke("RestartLevel", 2.5f);
    }

    private void RestartLevel(){
        LevelManager.Instance.RestartLevel();
    }
}