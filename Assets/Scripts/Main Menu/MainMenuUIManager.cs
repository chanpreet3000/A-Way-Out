using UnityEngine;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject levelSelectUI;
    public void PlayButtonClicked()
    {
        mainMenuUI.SetActive(false);
        levelSelectUI.SetActive(true);
        Camera.main.GetComponent<Animator>().SetBool("levelselect", true);
    }

    public void QuitButtonClicked()
    {
        Application.Quit();
    }

    public void HowToPlayButtonClicked()
    {
    }

    public void SettingsButtonClicked()
    {
    }
    public void OnLevelSelectBackButton()
    {
        mainMenuUI.SetActive(true);
        levelSelectUI.SetActive(false);
        Camera.main.GetComponent<Animator>().SetBool("levelselect", false);
    }

}
