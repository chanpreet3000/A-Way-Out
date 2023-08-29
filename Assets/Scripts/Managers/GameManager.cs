using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    private int currentLevel = -1;
    public static string UNLOCKED_LEVEL_KEY = "UNLOCKED_LEVEL_KEY";


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
        Debug.Log("Level " + currentLevel + " Completed!");
        AudioManager.PlayAudio(AudioManager.Sound.LevelCompleted);

        //
        PlayerPrefs.SetInt(UNLOCKED_LEVEL_KEY, Mathf.Max(GetUnlockedLevels(), currentLevel + 1));

        FindObjectOfType<PlayerHUD>().OpenLevelCompleteUI();
    }
    public void OpenLevel(int levelName)
    {
        currentLevel = levelName;
        SceneManager.LoadScene("Level " + levelName);
    }
    public int GetUnlockedLevels()
    {
        return PlayerPrefs.GetInt(UNLOCKED_LEVEL_KEY, 1);
    }
    public int GetCurrentLevel() {
        return currentLevel;
    }
}
