using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectSelectController : MonoBehaviour
{
    [SerializeField] private GameObject attachObject;
    [SerializeField] private float attachDistance = 50;
    private Vector2 _initialPosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _initialPosition = transform.localPosition;
    }

    public void OnDragEnd()
    {
        if(Vector2.Distance(transform.position, attachObject.transform.position) < attachDistance)
        {
            // Ставим объект
            attachObject.SetActive(false);
            gameObject.SetActive(false);
        }
        else
        {
            transform.localPosition = _initialPosition;
        }
    }

    public void OnDrag()
    {
        transform.position = Mouse.current.position.ReadValue();
    }
}
