using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private float movePosition = 10f;

    private void Start()
    {
        Move();
    }

    private void Update()
    {
        transform.LookAt(playerPosition);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Bullet"))
        {
            return;
        }

        Debug.Log("Bullet hit target!");
        Destroy(other.gameObject);
        Move();
    }

    private void Move()
    {
        var newPosition = new Vector3(
            Random.Range(-movePosition, movePosition),
            transform.position.y,
            Random.Range(-movePosition, movePosition)
        );
        
        transform.position = playerPosition.position + newPosition;
    }
}
