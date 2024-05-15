using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSequence : MonoBehaviour
{
    public float jumpForce = 10f;
    public float jumpInterval = 0.25f;
    public GameObject[] objectsToJump;

    private int currentIndex = 0;
    private bool jumping = false;

    void Update()
    {

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

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogWarning("Rigidbody2D component not found on " + obj.name + ". Skipping jump.");
        }
    }
}