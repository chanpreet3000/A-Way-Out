using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour
{
    [SerializeField] private Sprite lockedSprite;
    public void SetLevelNumber(int levelNumber)
    {
        if(levelNumber == -1)
        {
            GetComponent<Image>().sprite = lockedSprite;
            GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false);
        }
        else
        {
            GetComponentInChildren<TextMeshProUGUI>().text = levelNumber.ToString();
            GetComponent<Button>().onClick.AddListener(() =>
            {
                LevelManager.OpenLevel(levelNumber);
            });
        }
    }
}
