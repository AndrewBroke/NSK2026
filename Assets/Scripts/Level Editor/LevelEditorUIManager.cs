using UnityEngine;

public class LevelEditorUIManager : MonoBehaviour
{
    [SerializeField] GameObject furnitureParent;

    /// <summary>
    /// Удаление последнего объекта в редакторе
    /// </summary>
    public void DeleteLastObject()
    {
        FurnitureObjectController[] furnitures = furnitureParent.GetComponentsInChildren<FurnitureObjectController>();

        if (furnitures.Length > 0)
        {
            furnitures[furnitures.Length - 1].DeleteObject();
        } 
    }

    /// <summary>
    /// Вращение последнего объекта в редакторе
    /// </summary>
    public void RotateLastObject()
    {
        FurnitureObjectController[] furnitures = furnitureParent.GetComponentsInChildren<FurnitureObjectController>();

        if( furnitures.Length > 0 )
        {
            furnitures[furnitures.Length - 1].RotateObject();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            RotateLastObject();
        }

        if(Input.GetKey(KeyCode.LeftControl))
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                DeleteLastObject();
            }
        }
    }
}
