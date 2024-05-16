using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpAmount;
    float inputMovement;
    public Animator anim;

    Rigidbody2D rb;

    bool touchesGround;
    public Transform groundChecker;
    public LayerMask groundMask;

    public float radius;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        touchesGround = Physics2D.OverlapCircle(groundChecker.position, radius, groundMask);

        inputMovement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(inputMovement * speed, rb.velocity.y);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("running", true);
        } else if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("running", false);
        }
        if (touchesGround && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            rb.velocity = Vector2.up * jumpAmount;
        }
        
    }
}
