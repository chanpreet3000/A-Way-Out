using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    [SerializeField] private GameObject levelSelectGameObject;
    [SerializeField] private int totalLevels;
    void Start()
    {
        int unlockedLevels = GameManager.Instance.GetUnlockedLevels();
        for (int level = 1; level <= totalLevels; level++)
        {
            GameObject localObject = Instantiate(levelSelectGameObject, transform);
            if(level > unlockedLevels)
            {
                localObject.GetComponent<LevelSelectButton>().SetLevelNumber(-1);
            }
            else
            {
                localObject.GetComponent<LevelSelectButton>().SetLevelNumber(level);
            }
        }
    }
}
