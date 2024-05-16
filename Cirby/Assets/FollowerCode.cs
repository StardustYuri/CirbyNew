using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerCode : MonoBehaviour
{
    bool touchesGround;
    public Transform groundChecker;
    public LayerMask groundMask;
    public float radius;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (touchesGround && Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }
    private void FixedUpdate()
    {
        touchesGround = Physics2D.OverlapCircle(groundChecker.position, radius, groundMask);

       
    }
}
