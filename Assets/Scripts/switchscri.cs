using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchscri : MonoBehaviour
{
    public Material Red, Green;
    public GameObject Door;
    private void OnCollisionStay(Collision collision)
    {
        GetComponent<MeshRenderer>().material = Green;
        Door.GetComponentInChildren<Animator>().SetBool("opening", true);
    }
    private void OnCollisionExit(Collision collision)
    {
        GetComponent<MeshRenderer>().material = Red;
        Door.GetComponentInChildren<Animator>().SetBool("opening", false);
    }
}
