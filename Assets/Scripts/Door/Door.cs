using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAnimator;
    public Material onCollisionEnterMaterial, onCollisionExitMaterial;
    public DoorSwitch doorSwitch;
    public Vector3 switchPosition;
    public Vector3 switchRotation = Vector3.zero;

    private void Start()
    {
        doorSwitch.transform.position = switchPosition;
        doorSwitch.ColorRed();
        doorSwitch.transform.localRotation = Quaternion.Euler(switchRotation);
    }

    private void OnValidate()
    {
        doorSwitch.transform.position = switchPosition;
        doorSwitch.ColorRed();
        doorSwitch.transform.localRotation = Quaternion.Euler(switchRotation);
    }
}
