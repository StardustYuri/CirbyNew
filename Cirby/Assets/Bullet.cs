using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float speed;
    public Transform character;
    public float lifetime = 3f;
    public float invincibilityDuration = 0.1f; // Time in seconds before the bullet can collide with objects

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject bullet = Instantiate(projectilePrefab, character.position, character.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = character.right * speed;
            Destroy(bullet, lifetime);

            // Start the invincibility coroutine
            StartCoroutine(EnableCollisionAfterDelay(bullet));
        }
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
