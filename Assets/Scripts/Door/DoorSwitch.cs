using UnityEngine;

public class DoorSwitch : MonoBehaviour
{

    [SerializeField] private Door door;
    [SerializeField] private MeshRenderer mr;
    [SerializeField] private Material onCollisionEnterMaterial, onCollisionExitMaterial;

    private bool Check(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("SwitchActivator")) return true;
        return false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!Check(other)) return;
        mr.material = onCollisionEnterMaterial;
        door.SetDoorOpened(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!Check(other)) return;
        mr.material = onCollisionExitMaterial;
        door.SetDoorOpened(false);
    }
}
