using UnityEngine;
using static AudioManager;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)_instance= (Instantiate(Resources.Load("GameManager")) as GameObject).GetComponent<GameManager>();
            return _instance;
        }
    }

    [System.Serializable]
    public class SoundAudioClip
    {
        public Sound sound;
        public AudioClip audioClip;
    }
    public  SoundAudioClip[] soundAudioClipArray;

    public void LevelCompleted()
    {
        AudioManager.PlayAudio(Sound.LevelCompleted);
        Debug.Log("Level Completed!");
    }
}
