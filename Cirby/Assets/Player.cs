using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpAmount; //for player
    float inputMovement;

    Rigidbody2D rb;

    bool touchesGround;
    public Transform groundChecker;
    public LayerMask groundMask;
    public float radius;

<<<<<<< Updated upstream
    
    public float jumpInterval = 0.25f;
    public float jumpforce; //for followers
    public GameObject[] objectsToJump;
    
=======
    public float jumpForce = 5f;
    public float jumpInterval = 0.25f;
    public GameObject[] objectsToJump;

>>>>>>> Stashed changes
    private int currentIndex = 0;
    private bool jumping = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

<<<<<<< Updated upstream
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

=======
        // Hide the cursor and lock it to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
>>>>>>> Stashed changes
    }


    private void FixedUpdate()
    {
        touchesGround = Physics2D.OverlapCircle(groundChecker.position, radius, groundMask);

        inputMovement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(inputMovement * speed, rb.velocity.y);
    }

    private void Update()
    {
        if (touchesGround && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            rb.velocity = Vector2.up * jumpAmount;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!jumping)
            {
                jumping = true;
                StartCoroutine(StartJumpSequence());
            }
            else
            {
                jumping = false;
            }
        }
    }
    IEnumerator StartJumpSequence()
    {
        while (jumping && currentIndex < objectsToJump.Length)
        {
<<<<<<< Updated upstream
            GameObject currentObject = objectsToJump[currentIndex];
            Transform currentGroundChecker = currentObject.GetComponentInChildren<Transform>(); // Assuming groundChecker is a child object

            // Perform ground check using the current object's groundChecker
            bool touchesGround = Physics2D.OverlapCircle(currentGroundChecker.position, radius, groundMask);

            // Check if the current object touches the ground
            if (touchesGround)
            {
                Jump(currentObject); // Call the Jump function with the current object
            }

=======
            // Skip jumping if currentIndex is 0
            if (currentIndex == 0)
            {
                currentIndex++;
                continue; // Skip the rest of the loop and start from the beginning
            }

            Jump(objectsToJump[currentIndex]);
>>>>>>> Stashed changes
            currentIndex++;
            yield return new WaitForSeconds(jumpInterval);
        }

        jumping = false;
        currentIndex = 0;
    }


    void Jump(GameObject obj)
    {
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
<<<<<<< Updated upstream
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            Debug.Log("Jump Object");
=======
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
>>>>>>> Stashed changes
        }
        else
        {
            Debug.LogWarning("Rigidbody2D component not found on " + obj.name + ". Skipping jump.");
        }
    }
}
