using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    public float floatSpeed = 2f;      
    public float floatHeight = 0.5f;   
    public float rotationSpeed = 90f;  

    private Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        transform.Rotate(180.0f * Time.deltaTime, 0.0f, 0.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(GameManager.Instance != null)
            {
                GameManager.Instance.CollectCoin();
            }
            Destroy(this.gameObject);
        }    
    }
}
