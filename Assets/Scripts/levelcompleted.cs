using UnityEngine;
using UnityEngine.SceneManagement;

public class levelcompleted : MonoBehaviour
{   
    public void loadnextlevel()
    {
        if (SceneManager.GetActiveScene().buildIndex%5!=0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
            PlayerPrefs.SetInt("LevelCompleted", PlayerPrefs.GetInt("LevelCompleted", 0) + 1);
        }
    }
}
