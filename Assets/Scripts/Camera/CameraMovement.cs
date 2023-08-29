using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float smoothSpeed;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;
    private Transform player;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject.transform;
        transform.localRotation = Quaternion.Euler(rotationOffset);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, positionOffset + player.position, smoothSpeed * Time.deltaTime);
    }
}
