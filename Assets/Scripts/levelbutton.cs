using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelbutton : MonoBehaviour
{
    public Button btn;
    public int levelno;
    private void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("LevelCompleted", 1) >= levelno)
        {
            btn.interactable = true;
        }
        else
        {
            btn.interactable = false;
        }
    }
    public void Onbtncliked()
    {
        SceneManager.LoadScene(levelno);
    }
}