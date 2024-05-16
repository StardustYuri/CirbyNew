using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpAmount; //for player
    float inputMovement;
    public Animator anim;

    Rigidbody2D rb;

    bool touchesGround;
    public Transform groundChecker;
    public LayerMask groundMask;
    public float radius;


    public float jumpInterval = 0.25f;
    public float jumpforce; //for followers
    public GameObject[] objectsToJump;


    private int currentIndex = 0;
    private bool jumping = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Hide the cursor and lock it to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
            GameObject currentObject = objectsToJump[currentIndex];
            Transform currentGroundChecker = currentObject.GetComponentInChildren<Transform>();
            bool touchesGround = Physics2D.OverlapCircle(currentGroundChecker.position, radius, groundMask);

            if (touchesGround)
            {
                Jump(currentObject);
            }


            if (currentIndex == 0)
            {
                currentIndex++;
                continue;
            }

            Jump(objectsToJump[currentIndex]);

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

            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            Debug.Log("Jump Object");


        }
        else
        {
            Debug.LogWarning("Rigidbody2D component not found on " + obj.name + ". Skipping jump.");
        }
    }
}
