using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenuui : MonoBehaviour
{
    public GameObject levelselectui;
    public void startbtnclicked()
    {
        gameObject.SetActive(false);
        levelselectui.SetActive(true);
        Camera.main.GetComponent<Animator>().SetBool("levelselect", true);
    }
    public void quitbtnclicked()
    {
        Application.Quit();
    }
    public void downloadbtnclicked()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.Channi.BallHalter3D");
    }
}
