using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectSelectController : MonoBehaviour
{
    [SerializeField] private GameObject attachPlaceUI;
    [SerializeField] private GameObject temporaryAttachPlaceUI;
    [SerializeField] private GameObject objectOnRover;
    [SerializeField] private float attachDistance = 50;
    private Vector2 _initialPosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _initialPosition = transform.localPosition;
    }

    public void OnDragEnd()
    {
        if(Vector2.Distance(transform.position, attachPlaceUI.transform.position) < attachDistance)
        {
            // Ставим объект
            attachPlaceUI.SetActive(false);
            temporaryAttachPlaceUI.transform.parent.gameObject.SetActive(true);
            gameObject.SetActive(false);
            temporaryAttachPlaceUI.SetActive(false);
            objectOnRover.SetActive(true);
        }
        else
        {
            transform.localPosition = _initialPosition;
            temporaryAttachPlaceUI.transform.parent.gameObject.SetActive(true);
            attachPlaceUI.SetActive(false);
        }
    }

    public void OnDragStart()
    {
        temporaryAttachPlaceUI.transform.parent.gameObject.SetActive(false);
        attachPlaceUI.SetActive(true);
    }

    public void OnDrag()
    {
        transform.position = Mouse.current.position.ReadValue();
    }
}
