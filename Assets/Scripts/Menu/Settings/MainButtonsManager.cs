using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButtonsManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Выход из игры или пауза редактора
    /// </summary>
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPaused = true;
#else
        Application.Quit();
#endif
    }
}
