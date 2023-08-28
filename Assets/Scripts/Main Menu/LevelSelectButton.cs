using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour
{
    private int levelNumber = -1;
    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            GameManager.Instance.OpenLevel("Level " + levelNumber);
        });
    }

    public void SetLevelNumber(int levelNumber)
    {
        this.levelNumber = levelNumber;
        GetComponentInChildren<TextMeshProUGUI>().text = levelNumber.ToString();
    }
}
