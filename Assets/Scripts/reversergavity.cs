using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reversergavity : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null && !other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().velocity += new Vector3(0,20*Time.deltaTime,0);
        }
    }
}
