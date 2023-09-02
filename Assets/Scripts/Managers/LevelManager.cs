using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int currentLevel = 0;
    [SerializeField] private Vector3 playerStartPosition = Vector3.zero;
    private static readonly int totalLevels = 10;
    private static readonly string UNLOCKED_LEVEL_KEY = "UNLOCKED_LEVEL_KEY";
    public static LevelManager Instance = null;


    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        GameObject player = Instantiate(Resources.Load("Player")) as GameObject;
        player.transform.position = playerStartPosition;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerStartPosition, 0.5f);
    }

    public void LevelCompleted()
    {
        Debug.Log("Level " + currentLevel + " Completed!");
        AudioManager.Instance.PlayAudio(Sound.LevelCompleted);

        //
        PlayerPrefs.SetInt(UNLOCKED_LEVEL_KEY, Mathf.Max(GetUnlockedLevels(), currentLevel + 1));
        FindObjectOfType<PlayerHUD>().OpenLevelCompleteUI();
    }

    public void OpenNextLevel()
    {
        if (currentLevel == totalLevels)
        {
            OpenMainMenuLevel();
        }
        else
        {
            OpenLevel(currentLevel + 1);
        }
    }
    public static int GetUnlockedLevels()
    {
        return PlayerPrefs.GetInt(UNLOCKED_LEVEL_KEY, 1);
    }
    public int GetCurrentLevel()
    {
        return currentLevel;
    }
    public void RestartLevel()
    {
        OpenLevel(currentLevel);
    }

    public void OpenMainMenuLevel()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public static void OpenLevel(int number){
        SceneManager.LoadScene("Level " + number);
    }
}
