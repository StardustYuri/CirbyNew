using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class CirbyMove : MonoBehaviour
{
    public List<Transform> waypoints;
    public float moveSpeed;
    public int target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[target].position, moveSpeed * Time.deltaTime);
        //kristen
    }
    private void FixedUpdate()
    {
        if (transform.position == waypoints[target].position)
        {
                transform.eulerAngles = new Vector3(0, 180, 0);
               
            if (target == waypoints.Count - 1)
            {

                target = 0;
            }
            else
            {
                target += 1;
            }
        }
    }
}
//kristen was here
