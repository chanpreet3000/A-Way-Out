using UnityEngine;

public class LavaFlow : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private Renderer mr;

    private float offset = 0f;

    void FixedUpdate()
    {
        offset += Time.fixedDeltaTime * speed;
        mr.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
