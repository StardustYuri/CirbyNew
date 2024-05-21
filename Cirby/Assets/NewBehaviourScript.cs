using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpreadShooterAuto : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float shootInterval = 1f; // Interval between each shot
    public float shootForce = 10f;
    public int numProjectiles = 3;
    public float spreadAngle = 30f;
    public float invincibilityDuration = 0.1f;
    public int maxHealth = 6;
    private int currentHealth;
   

    private float lastShootTime;

    void Start()
    {
        lastShootTime = Time.time; // Initialize last shoot time
        currentHealth = maxHealth; // Set initial health
    }

    void Update()
    {
        // Check if enough time has passed since last shot
        if (Time.time - lastShootTime > shootInterval)
        {

            ShootSpread();
            lastShootTime = Time.time; // Update last shoot time
            
        }
    }

    void ShootSpread()
    {
        // Iterate through each projectile in the spread
        for (int i = 0; i < numProjectiles; i++)
        {
            // Calculate a random angle within the spread angle range
            float randomAngle = Random.Range(-spreadAngle / 2f, spreadAngle / 2f);

            // Rotate the shoot point by the random angle
            Quaternion rotation = Quaternion.Euler(0f, 0f, randomAngle);

            // Instantiate the projectile at the rotated shoot point
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, rotation);

            // Get the Rigidbody2D component of the projectile
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            // Apply force to the projectile in the direction of its right vector
            if (rb != null)
            {
                // Calculate the direction vector based on the rotated angle
                Vector2 shootDirection = rotation * Vector2.left;

                // Apply force in the calculated direction
                rb.velocity = shootDirection * shootForce;
            }

            // Enable collision for the projectile after the delay
            StartCoroutine(EnableCollisionAfterDelay(projectile));

            // Destroy the projectile after 5 seconds
            Destroy(projectile, 5f);
        }
    }





    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Implement death behavior here, such as disabling the GameObject or triggering an animation.
        Debug.Log("Player died");
        Destroy(gameObject); // Example: Destroy the GameObject
    }
    private IEnumerator EnableCollisionAfterDelay(GameObject bullet)
    {
        // Disable the bullet's collider initially
        Collider2D bulletCollider = bullet.GetComponent<Collider2D>();
        bulletCollider.enabled = false;

        // Wait for the invincibility duration
        yield return new WaitForSeconds(invincibilityDuration);

        // Enable the bullet's collider after the delay
        if (bullet != null)
        {
            bulletCollider.enabled = true;
        }
    }
}

