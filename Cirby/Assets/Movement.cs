using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float runSpeed = 0.6f; // Running speed.
    public float jumpForce = 2.6f; // Jump height.

    public Sprite jumpSprite; 

    private Rigidbody2D body; 
    private SpriteRenderer sr; 
    private Animator animator; 

    private bool isGrounded; 
    public GameObject groundCheckPoint; 
    public float groundCheckRadius; 
    public LayerMask groundLayer; 

    private bool jumpPressed = false; 
    private bool APressed = false; 
    private bool DPressed = false;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>(); 
        sr = GetComponent<SpriteRenderer>(); 
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) jumpPressed = true; 
        if (Input.GetKey(KeyCode.A)) APressed = true; 
        if (Input.GetKey(KeyCode.D)) DPressed = true; 
    }

    
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.transform.position, groundCheckRadius, groundLayer); // Checking if character is on the ground.

        if (APressed)
        {
            body.velocity = new Vector2(-runSpeed, body.velocity.y); 
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z); // Rotating the character object to the left.
            APressed = false; 
        }
        else if (DPressed)
        {
            body.velocity = new Vector2(runSpeed, body.velocity.y); 
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z); // Rotating the character object to the right.
            DPressed = false;
        }
        else body.velocity = new Vector2(0, body.velocity.y);

        
        if (jumpPressed && isGrounded)
        {
            body.velocity = new Vector2(0, jumpForce); 
            jumpPressed = false; 
        }
       
        if (!isGrounded)
        {
            animator.enabled = false; 
            sr.sprite = jumpSprite; 
        }
        else animator.enabled = true;
    }
}