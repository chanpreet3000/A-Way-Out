using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timerscript : MonoBehaviour
{
    public Text timertext;

    public float timertime;
    private void Start()
    {
        timertime = timertime + Time.time;
    }
    void Update()
    {
        timertext.text = (timertime - Time.time).ToString("0");
        if(Time.time>=timertime)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
