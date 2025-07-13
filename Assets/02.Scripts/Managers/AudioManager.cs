using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance {  get { return instance; } }

    public AudioSource bgmAudioSource;
    public AudioClip[] bgms;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;
    }

    public void PlayBGM(int index)
    {
        bgmAudioSource.clip = bgms[index];
        bgmAudioSource.Play();
    }
}