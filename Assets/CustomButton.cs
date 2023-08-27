using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour
{
    private Button button; 

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        AudioManager.PlayAudio(AudioManager.Sound.ButtonClick);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(OnButtonClick);
    }
}
