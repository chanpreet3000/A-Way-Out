using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAnimator;
    public Material onCollisionEnterMaterial, onCollisionExitMaterial;
    public DoorSwitch doorSwitch;
    public Vector3 switchPosition;

    private void Start()
    {
        doorSwitch.transform.position = switchPosition;
        doorSwitch.ColorRed();
    }

    private void OnValidate()
    {
        doorSwitch.transform.position = switchPosition;
        doorSwitch.ColorRed();
    }
}
