using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private CarController carController;
    [SerializeField] private float coolDown = 1;
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform rocketSpawnPoint;
    private bool _canUseWings = true;
    private bool _canUseRocket = true;

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Активация крыльев
    /// </summary>
    public void ActivateWings()
    {
        if(_canUseWings)
        {
            carController.Jump();
            _canUseWings = false;
            StartCoroutine("CoolDownWings");
        }
    }

    public void ActivateRocket()
    {
        if(_canUseRocket)
        {
            Instantiate(
                rocketPrefab, 
                rocketSpawnPoint.position, 
                rocketPrefab.transform.rotation
            );
            _canUseRocket = false;
            StartCoroutine("CoolDownRocket");
        }
    }

    /// <summary>
    /// Кулдаун крыльев
    /// </summary>
    /// <returns></returns>
    IEnumerator CoolDownWings()
    {
        yield return new WaitForSeconds(coolDown);
        _canUseWings = true;
    }

    /// <summary>
    /// Кулдаун ракеты
    /// </summary>
    /// <returns></returns>
    IEnumerator CoolDownRocket()
    {
        yield return new WaitForSeconds(coolDown);
        _canUseRocket = true;
    }
}
