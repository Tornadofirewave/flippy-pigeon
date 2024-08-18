using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BirdShoot : MonoBehaviour
{
    public GameObject projectilePrefab;  // Assign the projectile prefab in the Inspector
    public float projectileSpeed = 10f;  // Speed of the projectile

    void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        // Instantiate the projectile at the current position of the shooter
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Get the Rigidbody2D component to apply force
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Apply force to move the projectile directly to the right
        rb.velocity = Vector2.right * projectileSpeed;
    }
}