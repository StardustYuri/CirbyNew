using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    // Public field to set the reset position in the Unity editor
    public Vector2 resetPosition = new Vector2(4.57f, -0.79f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // This method is called when the collider other enters the trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object has the tag "Player"
        if (other.gameObject.CompareTag("Player"))
        {
            // Reset the position of the player object to the specified reset position
            other.transform.position = resetPosition;
        }
    }
}
