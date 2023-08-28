using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    private static string currentLevel = "NO-DATA";
    
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)_instance= (Instantiate(Resources.Load("GameManager")) as GameObject).GetComponent<GameManager>();
            return _instance;
        }
    }

    [System.Serializable]
    public class SoundAudioClip
    {
        public AudioManager.Sound sound;
        public AudioClip audioClip;
    }
    public  SoundAudioClip[] soundAudioClipArray;

    public void LevelCompleted()
    {
        AudioManager.PlayAudio(AudioManager.Sound.LevelCompleted);
        Debug.Log("Level Completed!");
    }
    public void OpenLevel(string levelName)
    {
        currentLevel = levelName;
        SceneManager.LoadScene(levelName);
    }
}
