using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform door;
    [SerializeField] private DoorSwitch doorSwitch;
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private Vector3 switchPosition;
    [SerializeField] private Vector3 switchRotation = Vector3.zero;
    [SerializeField] private float speed = 1.0f;

    private bool doorOpened = false;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = door.transform.position;
        doorSwitch.transform.position = switchPosition;
        doorSwitch.transform.localRotation = Quaternion.Euler(switchRotation);
    }

    private void OnValidate()
    {
        doorSwitch.transform.position = switchPosition;
        doorSwitch.transform.localRotation = Quaternion.Euler(switchRotation);
    }

    private void FixedUpdate()
    {
        if (doorOpened)
        {
            door.transform.position = Vector3.Lerp( door.transform.position, endPosition, speed * Time.fixedDeltaTime);
        }
        else
        {
            door.transform.position = Vector3.Lerp(door.transform.position, startPosition, speed * Time.fixedDeltaTime);
        }
    }

    public void SetDoorOpened(bool val)
    {
        doorOpened = val;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(endPosition, 0.5f);
    }
}
