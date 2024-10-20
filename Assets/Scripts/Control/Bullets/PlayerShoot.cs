using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;  
    public Transform firePoint;      
    public float fireRate = 1f;      
    private float nextFireTime = 0f; 

    private void Update()
    {
        // Automatically fire bullets at regular intervals
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;  // Update the next fire time
        }
    }

    private void Shoot()
    {
        // Instantiate the bullet prefab at the fire point's position and rotation
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
