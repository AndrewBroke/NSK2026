using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameSettings defaultSettings;
    private UserSettings _userSettings = new UserSettings();
    private string _jsonPath;

    [Header("UI Settings Objects")]
    [SerializeField] private Dropdown screenResolutionDropdown;
    [SerializeField] private Toggle windowModeToggle;
    [SerializeField] private Toggle musicActiveToggle;
    [SerializeField] private Dropdown gameLanguageDropdown;

    [Header("Sound & Music")]
    [SerializeField] private AudioMixer mainAudioMixer;

    /// <summary>
    /// Берем настройки с интерфейса и сохраняем в _userSettings
    /// </summary>
    void GetSettingsFromUI()
    {
        _userSettings.windowModeActive = windowModeToggle.isOn;
        _userSettings.soundAndMusicActive = musicActiveToggle.isOn;

        _userSettings.gameLanguage = (GameLanguage)gameLanguageDropdown.value;
        _userSettings.screenResolution = (ResolutionOption)screenResolutionDropdown.value;
    }

    /// <summary>
    /// Сохранение настроек в JSON
    /// </summary>
    public void SaveUserSettings()
    {
        GetSettingsFromUI();
        string json = JsonUtility.ToJson(_userSettings, true);
        print(json);
        File.WriteAllText(_jsonPath, json);
        ApplyUserSettings();
    }

    /// <summary>
    /// Ставим настройки из _userSettings в UI
    /// </summary>
    void SetSettingsToUI()
    {
        windowModeToggle.isOn = _userSettings.windowModeActive;
        musicActiveToggle.isOn = _userSettings.soundAndMusicActive;
        gameLanguageDropdown.value = (int)_userSettings.gameLanguage;
        screenResolutionDropdown.value = (int)_userSettings.screenResolution;
    }

    /// <summary>
    /// Загрузка настроек из JSON и ставим на UI
    /// </summary>
    void LoadUserSettings()
    {
        if(File.Exists(_jsonPath))
        {
            string json = File.ReadAllText(_jsonPath);
            _userSettings = JsonUtility.FromJson<UserSettings>(json);
            SetSettingsToUI();
            ApplyUserSettings();
        }
        else
        {
            SaveUserSettings();
        }
        
    }

    /// <summary>
    /// Сброс настроек по умаолчанию
    /// </summary>
    public void ResetSettingsToDefault()
    {
        _userSettings.screenResolution = defaultSettings.screenResolution;
        _userSettings.gameLanguage = defaultSettings.gameLanguage;
        _userSettings.windowModeActive = defaultSettings.windowModeActive;
        _userSettings.soundAndMusicActive = defaultSettings.soundAndMusicActive;
        SetSettingsToUI();
        SaveUserSettings();
    }

    /// <summary>
    /// Применение настроек _userSettings
    /// </summary>
    void ApplyUserSettings()
    {
        switch (_userSettings.screenResolution)
        {
            case ResolutionOption.R1280x720:
                Screen.SetResolution(1280, 720, !_userSettings.windowModeActive);
                break;
            case ResolutionOption.R1366x768:
                Screen.SetResolution(1366, 768, !_userSettings.windowModeActive);
                break;
            case ResolutionOption.R1600x900:
                Screen.SetResolution(1600, 900, !_userSettings.windowModeActive);
                break;
            case ResolutionOption.R1920x1080:
                Screen.SetResolution(1920, 1080, !_userSettings.windowModeActive);
                break;
        }

        if (_userSettings.soundAndMusicActive)
        {
            mainAudioMixer.SetFloat("MasterVolume", 0);
        }
        else
        {
            mainAudioMixer.SetFloat("MasterVolume", -80);
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _jsonPath = Application.persistentDataPath + "/UserSettings.json";
        print(_jsonPath);
        LoadUserSettings();
    }
}
