using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    private AudioSource bgmSource;
    private float defaultBgmVolume;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        bgmSource = GetComponent<AudioSource>();
        if (bgmSource != null)
        {
            defaultBgmVolume = bgmSource.volume;
        }
    }

    public void SetPitch(float pitch)
    {
        if (bgmSource != null)
        {
            bgmSource.pitch = pitch;
        }
    }

    public void SetVolumeRatio(float ratio)
    {
        if (bgmSource != null)
        {
            bgmSource.volume = defaultBgmVolume * ratio;
        }
    }

    public void stopBGM()
    {
        if (bgmSource != null)
        {
            bgmSource.Stop();
        }
    }
}
