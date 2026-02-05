using UnityEngine;

public class FurnitureSpawnController : MonoBehaviour
{
    [SerializeField] private GameObject furniturePrefab;
    [SerializeField] private Transform furnitureParent;

    /// <summary>
    /// Спавним объект при клике мыши на него
    /// </summary>
    private void OnMouseDown()
    {
        SpawnFurnitureObject();
    }

    /// <summary>
    /// Спавн объекта мебели
    /// </summary>
    public void SpawnFurnitureObject()
    {
        GameObject newFurniture = Instantiate(furniturePrefab, transform.position, transform.rotation, furnitureParent);
        newFurniture.transform.localScale = transform.localScale;
    }
}
