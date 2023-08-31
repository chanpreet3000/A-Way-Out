using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnTriggerStay(Collider other)
    {
        animator.SetBool("activate", true);

        // TODO: Audio + Destory effect?
        Invoke("RestartLevel", 0.75f);
    }
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("activate", false);
    }

    private void RestartLevel()
    {
        GameManager.Instance.RestartLevel();
    }
}
