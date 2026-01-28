using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private WheelCollider frontLeftWheel, frontRightWheel;
    [SerializeField] private WheelCollider rearLeftWheel, rearRightWheel;

    [SerializeField] private float motorForce;
    [SerializeField] private float motorForceMultiplier = 1;

    private Rigidbody carRb;

    public bool isGameStarted;

    private void Start()
    {
        carRb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
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
}
