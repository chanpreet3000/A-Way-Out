using UnityEngine;
public class teleportscript : MonoBehaviour
{
    public GameObject portal1, portal2;
    public float cooldown=1f;

    private void OnTriggerEnter(Collider other)
    {
        if (Time.time >= cooldown)
        {
            if (other.name == "portal1")
            {
                transform.position = portal2.transform.position;
            }
            else if (other.name == "portal2")
            {
                transform.position = portal1.transform.position;
            }
            cooldown += Time.time;
        }
    }
}
