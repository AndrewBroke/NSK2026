using UnityEngine;

public class FurnitureSelectController : MonoBehaviour
{
    // Объект для включения
    [SerializeField] private GameObject targetFurnitureObject;

    // Массив остальных объектов для выключения
    [SerializeField] private GameObject[] otherFurnitureObjects;

    /// <summary>
    /// Активация нужного объекта интерьера и деактивация остальных
    /// </summary>
    public void ActivateObject()
    {
        for(int i = 0; i < otherFurnitureObjects.Length; i++)
        {
            otherFurnitureObjects[i].SetActive(false);
        }
        targetFurnitureObject.SetActive(true);
    }
}
