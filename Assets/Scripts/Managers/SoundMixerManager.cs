using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private AudioMixer audioMixer;

    public void SetMasterVolume(float volumeLevel)
    {
        audioMixer.SetFloat("masterVolume", Mathf.Log10(volumeLevel) * 20f);
    }
    
    public void SetSFXVolume(float volumeLevel)
    {
        audioMixer.SetFloat("soundFXVolume", Mathf.Log10(volumeLevel) * 20f);
    }
    
    public void SetMusicVolume(float volumeLevel)
    {
        audioMixer.SetFloat("musicVolume", Mathf.Log10(volumeLevel) * 20f);
    }
}
