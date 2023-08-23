using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelselect : MonoBehaviour
{
    public GameObject easylevelui, mediumlevelui, mainmenu;
    public Button easybtn,mediumbtn;

    private void Update()
    {
        if (PlayerPrefs.GetInt("LevelCompleted", 0) >= 5)
        {
            mediumbtn.interactable = true;
        }
        else
        {
            mediumbtn.interactable = false;
        }
    }
    public void easylevelselected()
    {
        easylevelui.SetActive(true);
        gameObject.SetActive(false);
    }
    public void traingselected()

    {
        SceneManager.LoadScene("training");
    }
    public void mediumlevelselected()
    {
        mediumlevelui.SetActive(true);
        gameObject.SetActive(false);
    }
    public void backbtn()
    {
        easylevelui.SetActive(false);
        mediumlevelui.SetActive(false);
        gameObject.SetActive(false);
        mainmenu.SetActive(true);
        Camera.main.GetComponent<Animator>().SetBool("levelselect", false);
    }
}
