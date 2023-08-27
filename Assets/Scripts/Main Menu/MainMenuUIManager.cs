using System.Collections;
using System.Collections.Generic;
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
    public void downloadbtnclicked()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.Channi.BallHalter3D");
    }
}
