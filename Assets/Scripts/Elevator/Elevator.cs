using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Elevator : MonoBehaviour
{
    [SerializeField] private Material Red, Green;
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private float speed = 0.05f;
    [SerializeField] private MeshRenderer mr;
    private bool isActive = false;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (isActive) return;

        //
        if (mr == null) return;
        if (!collision.collider.CompareTag("Player") && !collision.collider.CompareTag("SwitchActivator")) return;
        mr.material = Green;
        isActive = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (mr == null) return;
        if (!collision.collider.CompareTag("Player") && !collision.collider.CompareTag("SwitchActivator")) return;
        mr.material = Red;
        isActive = false;
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            transform.position = Vector3.Lerp(transform.position, endPosition, speed * Time.fixedDeltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, startPosition, speed * Time.fixedDeltaTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(endPosition, 0.5f);
    }
}
