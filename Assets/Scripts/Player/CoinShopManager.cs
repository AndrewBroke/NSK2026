using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinShopManager : MonoBehaviour
{
    [SerializeField] Text getFreeCoinsTextButton;
    [SerializeField] PlayerCoinManager playerCoinManager;
    private bool _canGetFreeCoins;
    private int _freeCoinsCooldown;

    public void GetFreeCoins(int coinAddValue)
    {
        if(_canGetFreeCoins)
        {
            playerCoinManager.AddCoins(coinAddValue);
            StartCoroutine("GetFreeCoinsCooldownTimer");
        }
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _canGetFreeCoins = true;
        _freeCoinsCooldown = 60;
    }

    /// <summary>
    /// Обратный отсчет менутного получения бесплатных монет
    /// </summary>
    /// <returns></returns>
    IEnumerator GetFreeCoinsCooldownTimer()
    {
        _canGetFreeCoins = false;

        getFreeCoinsTextButton.text = _freeCoinsCooldown / 60 + ":" + _freeCoinsCooldown % 60;
        for(int i = 0; i < 60; i++) 
        {
            yield return new WaitForSeconds(1);
            _freeCoinsCooldown--;
            getFreeCoinsTextButton.text = _freeCoinsCooldown / 60 + ":" + _freeCoinsCooldown % 60;
        }

        _canGetFreeCoins = true;
        getFreeCoinsTextButton.text = "GET";
        _freeCoinsCooldown = 60;

    }
}
