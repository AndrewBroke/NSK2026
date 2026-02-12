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

    private Rigidbody carRb;


    private void Start()
    {
        carRb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        HandleMotor();
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
    /// Прыжок на крылья
    /// </summary>
    public void Jump()
    {
        print("Jump");
        carRb.AddForce(transform.up * jumpStrength, ForceMode.Impulse);
    }

    /// <summary>
    /// Активация пропеллера
    /// </summary>
    public void ActivateSpeedUp()
    {
        motorForceMultiplier = fanActivateMultiplier;
    }

    /// <summary>
    /// Деактивация пропеллера
    /// </summary>
    public void DeactivateSpeedUp()
    {
        motorForceMultiplier = 1;
    }
}
