using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressTrap : MonoBehaviour
{
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float distance = 3f;

    private Vector3 pos;
    private float time = 0;
    private void Start()
    {
        pos = transform.position;
    }
    void FixedUpdate()
    {
        time += speed * Time.deltaTime;
        time -= Mathf.Floor(time);
        float location = distance * animationCurve.Evaluate(time);
        transform.position = pos + new Vector3(0, location, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.RestartLevel();
        }
    }
}
