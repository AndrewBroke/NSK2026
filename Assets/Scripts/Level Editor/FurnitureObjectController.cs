using UnityEngine;

public class FurnitureObjectController : MonoBehaviour
{
    public void DeleteObject()
    {
        Destroy(gameObject);
    }

    public void RotateObject()
    {
        transform.Rotate(0, -90, 0);
    }
}
