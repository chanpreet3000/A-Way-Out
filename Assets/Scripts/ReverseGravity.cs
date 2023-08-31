using UnityEngine;

public class ReverseGravity : MonoBehaviour
{
    [SerializeField] private float gravity = 1.0f;
    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.AddForce(new Vector3(0, gravity * Time.deltaTime, 0));
        }
    }
}
