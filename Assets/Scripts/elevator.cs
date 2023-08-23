using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    public Material Red, Green;
    private void OnCollisionStay(Collision collision)
    {
        GetComponent<MeshRenderer>().material = Green;
        GetComponent<Animator>().SetBool("elevate", true);
    }
    private void OnCollisionExit(Collision collision)
    {
        GetComponent<MeshRenderer>().material = Red;
        GetComponent<Animator>().SetBool("elevate", false);
    }
}
