using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float movePosition = 10f;
    
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
            transform.position.z
        );
        
        transform.position = newPosition;
    }
}
