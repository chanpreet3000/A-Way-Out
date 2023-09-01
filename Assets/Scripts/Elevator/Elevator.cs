using UnityEngine;
public class Elevator : MonoBehaviour
{
    [SerializeField] private float speed = 0.05f;
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private Material Red, Green;
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private MeshRenderer mr;
    private bool isActive = false;
    private Vector3 startPosition;
    private float time = 0f;

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
            time += speed * Time.fixedDeltaTime;
        }
        else
        {
            time -= speed * Time.fixedDeltaTime;
        }

        float maxTime = animationCurve.keys[animationCurve.length - 1].time;
        time = Mathf.Clamp(time, 0f, maxTime);
        transform.position = Vector3.Lerp(startPosition, endPosition, time / maxTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(endPosition, 0.5f);
    }
}
