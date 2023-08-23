using UnityEngine;
using UnityEngine.SceneManagement;

public class levelprefs : MonoBehaviour
{ 
    void Update()
    {
        PlayerPrefs.SetInt("Currentlevel",SceneManager.GetActiveScene().buildIndex);
        if (PlayerPrefs.GetInt("Currentlevel", 0) > PlayerPrefs.GetInt("LevelCompleted", 0))
        {
            PlayerPrefs.SetInt("LevelCompleted", PlayerPrefs.GetInt("LevelCompleted", 0) + 1);
        }
    }
}