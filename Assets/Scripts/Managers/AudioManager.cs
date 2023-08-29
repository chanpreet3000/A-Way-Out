using UnityEngine;
public static class AudioManager
{
    public  enum  Sound
    {
        PlayerJump,
        LevelCompleted,
        DoorClosing,
        DoorOpening,
        ButtonClick
    }
    
    public static void PlayAudio(Sound sound)
    {
        AudioClip audioClip = GetAudioClip(sound);
        if (audioClip == null) return;
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audiosource = soundGameObject.AddComponent<AudioSource>();
        soundGameObject.AddComponent<DontDestory>();
        audiosource.loop = false;
        audiosource.volume = 1.0f;
        audiosource.pitch = 1.0f;
        audiosource.PlayOneShot(audioClip);
        Object.Destroy(soundGameObject, audioClip.length);
    }
    public static AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameManager.SoundAudioClip item in GameManager.Instance.soundAudioClipArray)
        {
            if (item.sound == sound) return item.audioClip;
        }
        return null;
    }
}
