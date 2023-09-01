using UnityEngine;

public class DoorSwitch : MonoBehaviour
{

    [SerializeField] private Door door;
    [SerializeField] private MeshRenderer mr;
    [SerializeField] private Material onCollisionEnterMaterial, onCollisionExitMaterial;

    private void OnCollisionStay(Collision collision)
    {
        //
        if (door == null || mr == null) return;
        if (!collision.collider.CompareTag("Player") && !collision.collider.CompareTag("SwitchActivator")) return;
        ColorGreen();
        door.SetDoorOpened(true);
    }
    private void OnCollisionExit(Collision collision)
    {
        if (door == null || mr == null) return;
        if (!collision.collider.CompareTag("Player") && !collision.collider.CompareTag("SwitchActivator")) return;
        ColorRed();
        door.SetDoorOpened(false);
    }
    private void ColorRed()
    {
        if (mr == null) return;
        mr.material = onCollisionExitMaterial;
    }
    private void ColorGreen()
    {
        if (mr == null) return;
        mr.material = onCollisionEnterMaterial;
    }
}
