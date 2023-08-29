using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject levelCompleteUI;
    [SerializeField] private TextMeshProUGUI levelStartText;

    private void Start()
    {
        levelStartText.SetText("Level " + GameManager.Instance.GetCurrentLevel());
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
        pauseUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenuBtnClicked()
    {
        pauseUI.SetActive(false);
        SceneManager.LoadScene("Main Menu");
    }
    public void OpenLevelCompleteUI()
    {
        levelCompleteUI.SetActive(true);
    }

    public void NextLevelBtnClicked()
    {
        GameManager.Instance.OpenLevel(GameManager.Instance.GetCurrentLevel() + 1);
    }
}
