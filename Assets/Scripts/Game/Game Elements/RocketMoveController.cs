using UnityEngine;

public class RocketMoveController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;
    Rigidbody _rb;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.linearVelocity = transform.up * moveSpeed;
    }
}
