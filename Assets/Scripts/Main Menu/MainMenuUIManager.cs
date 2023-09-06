using UnityEngine;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject levelSelectUI;
    [SerializeField] private GameObject howToPlayUI;

    public void PlayButtonClicked()
    {
        howToPlayUI.SetActive(false);
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
        mainMenuUI.SetActive(false);
        levelSelectUI.SetActive(false);

        howToPlayUI.SetActive(true);
        Camera.main.GetComponent<Animator>().SetBool("levelselect", true);
    }
    public void OnLevelSelectBackButton()
    {
        levelSelectUI.SetActive(false);
        howToPlayUI.SetActive(false);

        mainMenuUI.SetActive(true);
        Camera.main.GetComponent<Animator>().SetBool("levelselect", false);
    }

    public void OnBallHalter3DButton()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.Channi.BallHalter3D");
    }

    public void OnRateUsButton()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.Channi.AWAYOUT");
    }
}
