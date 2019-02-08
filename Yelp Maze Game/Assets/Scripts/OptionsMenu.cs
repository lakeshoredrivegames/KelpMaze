// Built in
using System.Collections;
using System.Collections.Generic;

// Unity
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class OptionsMenu : MonoBehaviour
{

    private void Start()
    {
        SetupResolutions();
    }

    private void SetupResolutions()
    {
        resolutions = new List<string>();

        availableResolutions = Screen.resolutions;

        float v;
        audioMixer.GetFloat("volume", out v);
        audioSlider.value = v;
        graphicsDropdown.value = QualitySettings.GetQualityLevel();

        resolutionDropdown.options.Clear();

        currentResolutionIndex = 0;
        for (int i = 0; i < availableResolutions.Length; i++)
        {
            if (availableResolutions[i].width == Screen.currentResolution.width && 
                availableResolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }

            string option = availableResolutions[i].width + " x " + 
                availableResolutions[i].height + " @ " + availableResolutions[i].refreshRate + "Hz";
            resolutions.Add(option);
        }

        resolutionDropdown.AddOptions(resolutions);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
	}

    public void SetResolution()
    {
            Screen.SetResolution(availableResolutions[resolutionDropdown.value].width,
                availableResolutions[resolutionDropdown.value].height, Screen.fullScreen);
    }
    public void SetGraphics(int graphicsIndex) { QualitySettings.SetQualityLevel(graphicsIndex); }
    public void SetVolume(float volume) { audioMixer.SetFloat("volume", volume); }
    public void SetFullscreen(bool isFullscreen) { Screen.fullScreen = isFullscreen; }
    public void GotoMenu() { SceneManager.LoadScene("MainMenu"); }

    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public Dropdown graphicsDropdown;
    public Slider audioSlider;

    private List<string> resolutions;
    private int currentResolutionIndex;
    private Resolution[] availableResolutions;
}
