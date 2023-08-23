using UnityEngine;
public class Exitscript : MonoBehaviour
{
    public GameObject panelanim;
    public AudioClip levelcompletesound;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            panelanim.GetComponent<Animator>().SetBool("ended", true);
            GetComponent<AudioSource>().PlayOneShot(levelcompletesound);
        }
    }
}
