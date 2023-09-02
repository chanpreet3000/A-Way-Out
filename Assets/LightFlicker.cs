using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private float maxIntensity = 12f;
    [SerializeField] private float speed = 1f;
    private Light lightComp;
    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        lightComp = GetComponent<Light>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float maxTime = animationCurve.keys[animationCurve.length - 1].time;
        time += speed * Time.fixedDeltaTime;
        if(time > maxTime)time -= time;
        lightComp.intensity = maxIntensity * animationCurve.Evaluate(time);
    }
}
