using UnityEngine;
using UnityEngine.UI;

public class PlayerCoinManager : MonoBehaviour
{
    [SerializeField] PlayerSaveManager playerSaveManager;
    [SerializeField] Text coinTextUI;
    private PlayerSaveData _playerData;

    public void AddCoins(int coinsAddValue)
    {
        playerSaveManager.playerData.coins += coinsAddValue;
        playerSaveManager.SavePlayerData();
        RenderCoinsToUI();
    }

    public void RenderCoinsToUI()
    {
        if(_playerData.coins < 1000)
        {
            coinTextUI.text = _playerData.coins.ToString();
        }
        else 
        { 
            coinTextUI.text = (_playerData.coins / 1000.0f).ToString() + "k";
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerData = playerSaveManager.playerData;
        RenderCoinsToUI();
    }

    
}
