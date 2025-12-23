using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    public static SoundMixerManager instance;
    [SerializeField] AudioMixer audioMixer;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        // Load saved values (default = 1f)
        float master = PlayerPrefs.GetFloat("MasterVolume", 1f);
        float sfx = PlayerPrefs.GetFloat("SoundFXVolume", 1f);
        float music = PlayerPrefs.GetFloat("MusicVolume", 1f);

        // Apply volumes to mixer
        ApplyVolume("MasterVolume", master);
        ApplyVolume("SoundFXVolume", sfx);
        ApplyVolume("MusicVolume", music);
    }

    public void SetMasterVolume(float value)
    {
        ApplyVolume("MasterVolume", value);
        PlayerPrefs.SetFloat("MasterVolume", value);
    }

    public void SetSoundFXVolume(float value)
    {
        ApplyVolume("SoundFXVolume", value);
        PlayerPrefs.SetFloat("SoundFXVolume", value);
    }

    public void SetMusicVolume(float value)
    {
        ApplyVolume("MusicVolume", value);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }
    private void ApplyVolume(string parameterName, float value)
    {
        float volume = Mathf.Clamp(value, 0.0001f, 1f);

        audioMixer.SetFloat(parameterName, Mathf.Log10(volume) * 20f);
    }

}
