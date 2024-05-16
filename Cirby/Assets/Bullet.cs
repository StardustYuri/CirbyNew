using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float speed;
    public Transform character;
    public float lifetime = 3f;
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
             void OnCollisionEnter2D(Collision2D collision)
            {

            }
        }
        
    }


}
