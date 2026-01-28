using UnityEditor;
using UnityEngine;

public class MainButtonsManager : MonoBehaviour
{
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
