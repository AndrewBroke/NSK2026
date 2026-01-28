using System.IO;
using UnityEngine;

public class PlayerSaveManager : MonoBehaviour
{
    public PlayerSaveData playerData = new PlayerSaveData();
    private string _jsonPath;

    /// <summary>
    /// Сохранение данных игрока
    /// </summary>
    public void SavePlayerData()
    {
        string json = JsonUtility.ToJson(playerData, true);
        print(_jsonPath);
        File.WriteAllText(_jsonPath, json);
    }

    /// <summary>
    /// Загрузка данных игрока
    /// </summary>
    public void LoadPlayerData()
    {
        if(File.Exists(_jsonPath))
        {
            string json = File.ReadAllText(_jsonPath);
            playerData = JsonUtility.FromJson<PlayerSaveData>(json);
        }
        else
        {
            SavePlayerData();
        }
    }

    void Awake()
    {
        _jsonPath = Application.persistentDataPath + "/PlayerData.json";
        //print(_jsonPath);
        LoadPlayerData();
    }
}
