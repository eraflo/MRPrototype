using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int spawnSpeed = 10;
    [SerializeField] private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
    }
    
    private void Update()
    {
        UpdateLine();
        
        if (!OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            return;
        }
        
        var obj = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        var rb = obj.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * spawnSpeed;
    }

    private void UpdateLine()
    {
        lineRenderer.SetPosition(0, transform.position);
        
        var mask = LayerMask.GetMask("Target");
        if (Physics.Raycast(transform.position, transform.forward, out var hit, 200f, mask))
        {
            lineRenderer.SetPosition(1, hit.point);
            lineRenderer.material.color = Color.green;
        }
        else
        {
            lineRenderer.SetPosition(1, transform.position + transform.forward * 100);
            lineRenderer.material.color = Color.red;
        }
    }
}
