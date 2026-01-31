using UnityEngine;

public class LooseController : MonoBehaviour
{
    [SerializeField] GameObject loosePanel;
    [SerializeField] AudioSource looseSound;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            loosePanel.SetActive(true);
            looseSound.Play();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
