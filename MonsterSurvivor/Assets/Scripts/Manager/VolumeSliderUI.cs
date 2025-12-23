using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderUI : MonoBehaviour
{
    public enum VolumeType { Master, SFX, Music }
    public VolumeType volumeType;
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();

        float savedValue = 1f;
        switch (volumeType)
        {
            case VolumeType.Master:
                savedValue = PlayerPrefs.GetFloat("MasterVolume", 1f);
                break;
            case VolumeType.SFX:
                savedValue = PlayerPrefs.GetFloat("SoundFXVolume", 1f);
                break;
            case VolumeType.Music:
                savedValue = PlayerPrefs.GetFloat("MusicVolume", 1f);
                break;
        }

        slider.value = savedValue;
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    void OnSliderValueChanged(float value)
    {
        switch (volumeType)
        {
            case VolumeType.Master:
                SoundMixerManager.instance.SetMasterVolume(value);
                break;
            case VolumeType.SFX:
                SoundMixerManager.instance.SetSoundFXVolume(value);
                break;
            case VolumeType.Music:
                SoundMixerManager.instance.SetMusicVolume(value);
                break;
        }
    }
}
