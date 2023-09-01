using UnityEngine;
public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class SoundAudioClip
    {
        public Sound sound;
        public AudioClip audioClip;
        public bool loop = false;
        public float volume = 1.0f;
    }
    [SerializeField] private SoundAudioClip[] soundAudioClipArray;

    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = Instantiate(Resources.Load("AudioManager")) as GameObject;
                _instance = obj.GetComponent<AudioManager>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }

    public void PlayAudio(Sound sound)
    {
        SoundAudioClip soundAudioClip = GetAudioClip(sound);
        if (soundAudioClip == null) return;
        //
        AudioClip audioClip = soundAudioClip.audioClip;
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audiosource = soundGameObject.AddComponent<AudioSource>();
        audiosource.loop = soundAudioClip.loop;
        audiosource.volume = soundAudioClip.volume;
        audiosource.PlayOneShot(audioClip);
        //
        DontDestroyOnLoad(soundGameObject);
        Destroy(soundGameObject, audioClip.length);
    }
    public SoundAudioClip GetAudioClip(Sound sound)
    {
        foreach (SoundAudioClip item in soundAudioClipArray)
        {
            if (item.sound == sound) return item;
        }
        return null;
    }
}
