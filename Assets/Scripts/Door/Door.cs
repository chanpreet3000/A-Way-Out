using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform door;
    [SerializeField] private DoorSwitch doorSwitch;
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private Vector3 switchPosition;
    [SerializeField] private Vector3 switchRotation = Vector3.zero;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private AnimationCurve animationCurve;

    private bool doorOpened = false;
    private Vector3 startPosition;
    private float time = 0f;

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
            time += speed * Time.fixedDeltaTime;
        }
        else
        {
            time -= speed * Time.fixedDeltaTime;
        }

        float maxTime = animationCurve.keys[animationCurve.length - 1].time;
        time = Mathf.Clamp(time, 0f, maxTime);
        door.transform.position = Vector3.Lerp( startPosition, endPosition, time / maxTime);
    }

    public void SetDoorOpened(bool val)
    {
        doorOpened = val;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(endPosition, 1f);
    }
}
