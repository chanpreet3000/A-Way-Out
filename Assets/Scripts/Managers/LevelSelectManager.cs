using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    [SerializeField] private GameObject levelSelectGameObject;
    [SerializeField] private int totalLevels;
    void Start()
    {
        int unlockedLevels = LevelManager.GetUnlockedLevels();
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
