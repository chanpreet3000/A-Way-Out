using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timer = 0f;
    private bool timerDone = false;

    private void FixedUpdate()
    {
        if(timerDone)return;
        timer -= Time.fixedDeltaTime;
        if (timer < 0f)
        {
            timerDone = true;
            if (!FindAnyObjectByType<PlayerMovement>().isLevelCompleted)
            {
                LevelManager.Instance.RestartLevel();
            }
        }
    }

    private void OnGUI()
    {
        Rect labelRect = new Rect(30, 30, 800, 120);

        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 50;

        GUI.Label(labelRect, "Time Left: " + Mathf.Ceil(timer) + "s", style);
    }
}
