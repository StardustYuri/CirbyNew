using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Transform character;
    public Vector2 resetPosition = new Vector2(4.57f, -0.79f);

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision detected with Mirby.");
            other.transform.position = resetPosition;
        }
    }
}
