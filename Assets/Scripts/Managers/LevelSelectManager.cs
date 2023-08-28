using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    [SerializeField] private GameObject levelSelectGameObject;
    [SerializeField] private int totalLevels;
    void Start()
    {
        for(int i = 0; i < totalLevels; i++)
        {
            GameObject localObject = Instantiate(levelSelectGameObject, transform);
            localObject.GetComponent<LevelSelectButton>().SetLevelNumber(i + 1);
        }
    }
}
