using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newswitchscript : MonoBehaviour
{
    public Material Red, Green;
    public GameObject Door;
    private void OnCollisionStay(Collision collision)
    {
        GetComponent<MeshRenderer>().material = Green;
        Door.GetComponentInChildren<Animator>().SetBool("opening", true);
    }
}
