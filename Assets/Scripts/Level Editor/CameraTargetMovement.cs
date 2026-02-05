using UnityEngine;

public class CameraTargetMovement : MonoBehaviour
{
    public void Move(float moveStep)
    {
        transform.Translate(new Vector3 (moveStep, 0, 0));
    }
}
