using UnityEngine;
using UnityEngine.InputSystem.XR;

public class CarController : MonoBehaviour
{
    [SerializeField] private WheelCollider frontLeftWheel, frontRightWheel;
    [SerializeField] private WheelCollider rearLeftWheel, rearRightWheel;

    [SerializeField] private float motorForce;
    [SerializeField] private float motorForceMultiplier = 1;
    [SerializeField] private float jumpStrength = 10;
    [SerializeField] private float fanActivateMultiplier = 3;

    [Header("Objects")]
    [SerializeField] private GameObject[] objectsOnRover;

    [Header("UI")]
    [SerializeField] private GameObject startButton;

    private Rigidbody carRb;

    public bool isGameStarted;

    private void Start()
    {
        carRb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (IsRoverReady() && startButton.activeSelf == false && !isGameStarted)
        {
            startButton.SetActive(true);
        }

        if (isGameStarted)
        {
            HandleMotor();
        }
    }

    /// <summary>
    /// Применение силы на коллайдеры колёс
    /// </summary>
    public void HandleMotor()
    {
        frontLeftWheel.motorTorque = motorForce * motorForceMultiplier;
        frontRightWheel.motorTorque = motorForce * motorForceMultiplier;
        rearLeftWheel.motorTorque = motorForce * motorForceMultiplier;
        rearRightWheel.motorTorque = motorForce * motorForceMultiplier;
    }

    /// <summary>
    /// Проверка, что ровер полностью собран
    /// </summary>
    /// <returns>true - собран, false - не собран</returns>
    private bool IsRoverReady()
    {
        for (int i = 0; i < objectsOnRover.Length; i++)
        {
            if (objectsOnRover[i].activeSelf == false)
            {
                return false;
            }
        }

        return true;
    }

    public void Jump()
    {
        print("Jump");
        carRb.AddForce(transform.up * jumpStrength, ForceMode.Impulse);
    }

    public void ActivateSpeedUp()
    {
        motorForceMultiplier = fanActivateMultiplier;
    }

    public void DeactivateSpeedUp()
    {
        motorForceMultiplier = 1;
    }
}
