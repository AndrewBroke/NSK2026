using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class testscticp : MonoBehaviour
{
    public AudioSource audioSource;
    InputAction interactAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        if(interactAction.WasPressedThisFrame())
        {
            audioSource.Play();
        }
    }
}
