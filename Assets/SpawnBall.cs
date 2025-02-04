using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private int spawnSpeed = 10;
    
    private void Update()
    {
        if (!OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            return;
        }
        
        var obj = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        var rb = obj.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * spawnSpeed;
    }
}
