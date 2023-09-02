using TMPro;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private GameObject playerControlUI;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject levelCompleteUI;
    [SerializeField] private GameObject playerDeadUI;
    [SerializeField] private TextMeshProUGUI levelStartText;

    private void Start()
    {
        levelStartText.SetText("Level " + LevelManager.Instance.GetCurrentLevel());
    }
    public void PauseBtnClicked()
    {
        pauseUI.SetActive(true);
    }
    public void ResumeBtnClicked()
    {
        pauseUI.SetActive(false);
    }
    public void RestartBtnClicked()
    {
        LevelManager.Instance.RestartLevel();
    }
    public void MainMenuBtnClicked()
    {
        LevelManager.Instance.OpenMainMenuLevel();
    }
    public void OpenLevelCompleteUI()
    {
        levelCompleteUI.SetActive(true);
    }

    public void OnPlayerDead()
    {
        playerControlUI.SetActive(false);
        playerDeadUI.SetActive(true);
    }

    public void NextLevelBtnClicked()
    {
        LevelManager.Instance.OpenNextLevel();
    }
}
