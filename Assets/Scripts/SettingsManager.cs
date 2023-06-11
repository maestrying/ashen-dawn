using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public List<AudioSource> musicSources = new List<AudioSource>();
    public List<AudioSource> soundSources = new List<AudioSource>();
    public List<GameObject> objectsWithSounds = new List<GameObject>();

    public Slider musicSlider;
    public Slider soundSlider;
    public Toggle fpsToggle;
    public GameObject fpsCounter;

    private float musicVolume;
    private float soundVolume;
    private bool showFps;

    public void Start()
    {
        foreach (GameObject obj in objectsWithSounds)
        {
            soundSources.Add(obj.GetComponent<AudioSource>());
        }

        if (PlayerPrefs.HasKey("musicVolume") && PlayerPrefs.HasKey("soundVolume"))
        {
            musicVolume = PlayerPrefs.GetFloat("musicVolume");
            soundVolume = PlayerPrefs.GetFloat("soundVolume");
        }
        else
        {
            DefaultVolumes();
        }

        UpdateVolumes();

        if (PlayerPrefs.HasKey("fps"))
        {
            fpsToggle.isOn = PlayerPrefs.GetInt("fps") == 1 ? true : false;
            fpsCounterState();
        }
    }
    public void MusicVolumeChange(float volume)
    {
        musicVolume = volume;
    }

    public void SoundVolumeChange(float volume)
    {
        soundVolume = volume;
    }

    public void fpsCounterState()
    {
        fpsCounter.SetActive(fpsToggle.isOn);
    }
    public void UpdateVolumes()
    {
        foreach (AudioSource source in soundSources)
        {
            source.volume = soundVolume;
        }

        foreach (AudioSource source in musicSources)
        {
            source.volume = musicVolume;
        }

        soundSlider.value = soundVolume;
        musicSlider.value = musicVolume;
    }

    public void DefaultVolumes()
    {
        musicVolume = 0.5f;
        soundVolume = 0.5f;
        showFps = false;
        UpdateVolumes();
    }

    public void SaveSettings()
    {
        fpsCounterState();
        UpdateVolumes();
        PlayerPrefs.SetInt("fps", showFps ? 1 : 0);
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.SetFloat("soundVolume", soundVolume);
        PlayerPrefs.Save();
    }
}
