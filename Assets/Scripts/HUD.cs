using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public GameObject pauseui;
    public void pausebtnclicked()
    {
        Time.timeScale = 0;
        pauseui.SetActive(true);
    }
    public void resumebuttonclicked()
    {
        Time.timeScale =1;
        pauseui.SetActive(false);
    }
    public void restartbuttonclicked()
    {
        Time.timeScale = 1;
        pauseui.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void mainmenubuttonclicked()
    {
        Time.timeScale = 1;
        pauseui.SetActive(false);
        SceneManager.LoadScene(0);

    }
}
