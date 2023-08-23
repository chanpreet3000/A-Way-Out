using UnityEngine;
using UnityEngine.SceneManagement;

public class trap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<Animator>().SetBool("trapactivated", true);
        Invoke("levelfailed", 0.3f);
    }
    private void OnTriggerExit(Collider other)
    {
        GetComponentInParent<Animator>().SetBool("trapactivated", false);
    }
    public void levelfailed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
