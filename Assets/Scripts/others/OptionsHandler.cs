using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

// Code très inspiré de https://answers.unity.com/questions/1704215/how-to-save-the-resolutions-for-the-options-menu.html
public class OptionsHandler : MonoBehaviour
{
    private const string resolutionWidthPlayerPrefKey = "ResolutionWidth";
    private const string resolutionHeightPlayerPrefKey = "ResolutionHeight";
    private const string resolutionRefreshRatePlayerPrefKey = "RefreshRate";
    private const string fullScreenPlayerPrefKey = "FullScreen";
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public Toggle fullScreenToggle;
    public Slider volumeSlider;
    float currentVolume;
    Resolution selectedResolution;
    Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {   
        resolutions = Screen.resolutions;
         LoadSettings();
         CreateResolutionDropdown();
 
         fullScreenToggle.onValueChanged.AddListener(SetFullscreen);
         resolutionDropdown.onValueChanged.AddListener(SetResolution);
    }

    private void LoadSettings()
     {
         selectedResolution = new Resolution();
         selectedResolution.width = PlayerPrefs.GetInt(resolutionWidthPlayerPrefKey, Screen.currentResolution.width);
         selectedResolution.height = PlayerPrefs.GetInt(resolutionHeightPlayerPrefKey, Screen.currentResolution.height);
         selectedResolution.refreshRate = PlayerPrefs.GetInt(resolutionRefreshRatePlayerPrefKey, Screen.currentResolution.refreshRate);
         
         fullScreenToggle.isOn = PlayerPrefs.GetInt(fullScreenPlayerPrefKey, Screen.fullScreen ? 1 : 0) > 0;
 
         Screen.SetResolution(
             selectedResolution.width,
             selectedResolution.height,
             fullScreenToggle.isOn
         );
     }


    private void CreateResolutionDropdown()
     {
         resolutionDropdown.ClearOptions();
         List<string> options = new List<string>();
         int currentResolutionIndex = 0;
         for (int i = 0; i < resolutions.Length; i++)
         {
             string option = resolutions[i].width + " x " + resolutions[i].height;
             options.Add(option);
             if (Mathf.Approximately(resolutions[i].width, selectedResolution.width) && Mathf.Approximately(resolutions[i].height, selectedResolution.height))
             {
                 currentResolutionIndex = i;
             }
         }
         resolutionDropdown.AddOptions(options);
         resolutionDropdown.value = currentResolutionIndex;
         resolutionDropdown.RefreshShownValue();
     }
    public void SetFullscreen(bool isFullscreen)
     {
         Screen.fullScreen = isFullscreen;
         PlayerPrefs.SetInt(fullScreenPlayerPrefKey, isFullscreen ? 1 : 0);
     }
     public void SetResolution(int resolutionIndex)
     {
         selectedResolution = resolutions[resolutionIndex];
         Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
         PlayerPrefs.SetInt(resolutionWidthPlayerPrefKey, selectedResolution.width);
         PlayerPrefs.SetInt(resolutionHeightPlayerPrefKey, selectedResolution.height);
         PlayerPrefs.SetInt(resolutionRefreshRatePlayerPrefKey, selectedResolution.refreshRate);
     }

      	
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        currentVolume = volume;
    }
}
