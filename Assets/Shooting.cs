using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int spawnSpeed = 10;
    
    private void Update()
    {
        if (!OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            return;
        }
        
        var obj = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        var rb = obj.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * spawnSpeed;
    }
}
