using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private CarController carController;
    [SerializeField] private float wingsCoolDown = 1;
    private bool _canUseWings = true;

    public void StartGame()
    {
        carController.isGameStarted = true;

    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateWings()
    {
        if(_canUseWings)
        {
            carController.Jump();
            _canUseWings = false;
            StartCoroutine("CoolDownWings");
        }
    }

    IEnumerator CoolDownWings()
    {
        yield return new WaitForSeconds(wingsCoolDown);
        _canUseWings = true;
    }
}
