using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour
{
    private Button button;
    [SerializeField] private AudioManager.Sound sound = AudioManager.Sound.ButtonClick;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            AudioManager.PlayAudio(sound);
        });
    }
}
