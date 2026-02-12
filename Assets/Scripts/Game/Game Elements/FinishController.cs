using UnityEngine;

public class FinishController : MonoBehaviour
{
    // Панель выигрыша
    [SerializeField] private GameObject winPanel;
    // Звук выигрыша
    [SerializeField] private AudioSource winSound;
    // rigidbody машины (для остановки)
    [SerializeField] Rigidbody playerRB;

    private void OnTriggerEnter(Collider other)
    {
        // Если финишная прямая столкнулась с игроком и он еще не остановлен
        if(other.CompareTag("Player") && !playerRB.isKinematic)
        {
            // Останавливаем игрока (или можно удалить)
            playerRB.isKinematic = true;
            // Включаем панель выигрыша
            winPanel.SetActive(true);
            // Проигрываем звук
            winSound.Play();
        }
    }
}
