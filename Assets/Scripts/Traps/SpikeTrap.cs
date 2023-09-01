using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnTriggerStay(Collider other)
    {
        animator.SetBool("activate", true);
    }
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("activate", false);
    }
}
