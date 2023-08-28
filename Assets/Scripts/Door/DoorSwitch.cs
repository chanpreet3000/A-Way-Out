using UnityEngine;

public class DoorSwitch : MonoBehaviour
{

    [SerializeField] private Door door;
    [SerializeField] private MeshRenderer mr;
    
    private void OnCollisionStay(Collision collision)
    {
        if (door == null || mr == null) return;
        if (!collision.collider.CompareTag("Player") && !collision.collider.CompareTag("SwitchActivator")) return;
        ColorGreen();
        door.doorAnimator.SetBool("opening", true);
    }
    private void OnCollisionExit(Collision collision)
    {
        if (door == null || mr == null) return;
        if (!collision.collider.CompareTag("Player") && !collision.collider.CompareTag("SwitchActivator")) return;
        ColorRed();
        door.doorAnimator.SetBool("opening", false);
    }
    public void ColorRed()
    {
        if (mr == null) return;
        mr.material = door.onCollisionExitMaterial;
    }
    public void ColorGreen()
    {
        if (mr == null) return;
        mr.material = door.onCollisionEnterMaterial;
    }
}
