using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;  // Reference to the bullet prefab
    public Transform firePoint;      // The point where the bullet will spawn
    public float fireRate = 1f;      // Time interval between shots
    private float nextFireTime = 0f; // Track when the next bullet can be fired

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
