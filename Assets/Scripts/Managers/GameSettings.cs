using UnityEngine;

public class GameSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Application.targetFrameRate = 144;
        QualitySettings.vSyncCount = 1;
        AudioManager.Instance.PlayLevelAudio();
    }
}
