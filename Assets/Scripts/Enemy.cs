using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform leftWaypoint;
    public Transform rightWaypoint;
    public float moveSpeed = 2f;

    private Vector3 currentTarget;
    private bool movingRight = true;

    void Start()
    {
        currentTarget = rightWaypoint.position;
    }

    void Update()
    {
        // Move the enemy towards the current target waypoint.
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime);

        // Check if the enemy has reached the current target.
        if (Vector3.Distance(transform.position, currentTarget) < 0.1f)
        {           
            // Switch the target waypoint.
            if (movingRight)
            {
                currentTarget = leftWaypoint.position;
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                currentTarget = rightWaypoint.position;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            movingRight = !movingRight;
        }
    }
}
