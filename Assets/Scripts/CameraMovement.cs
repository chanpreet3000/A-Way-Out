using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;
    public Vector3 offset;
    public float smoothSpeed = 10f;

    private void Update()
    {
        transform.position = Player.transform.position + offset;
    }
}
