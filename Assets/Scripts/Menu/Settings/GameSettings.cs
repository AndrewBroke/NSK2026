using UnityEngine;
/// <summary>
/// Настройки игры
/// </summary>
[CreateAssetMenu(fileName ="GameSettings", menuName = "ScriptableObjects/GameSettings")]
public class GameSettings : ScriptableObject
{
    public ResolutionOption screenResolution = ResolutionOption.R1600x900;
    public bool windowModeActive = false;
    public bool soundAndMusicActive = true;
    public GameLanguage gameLanguage = GameLanguage.English;
}