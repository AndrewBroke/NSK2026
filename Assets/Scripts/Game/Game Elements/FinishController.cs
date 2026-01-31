using UnityEngine;
using UnityEngine.UI;

public class FinishController : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private AudioSource winSound;
    [SerializeField] private PlayerCoinManager coinManager;
    [SerializeField] private int levelWinCoins = 15;
    [SerializeField] private Text levelWinCoinsText;
    [SerializeField] Rigidbody playerRB;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !playerRB.isKinematic)
        {
            playerRB.isKinematic = true;
            winPanel.SetActive(true);
            winSound.Play();
            coinManager.AddCoins(levelWinCoins);
            levelWinCoinsText.text = "+" + levelWinCoins.ToString();
        }
    }
}
