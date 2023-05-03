using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patroller : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2.0f;
    public float waitTime;

    private int currentWaypoint = 0;
    private bool isWaiting = false;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isWaiting)
        {
            MoveToNextWaypoint();
        }
        
    }

    void MoveToNextWaypoint()
    {
        if (waypoints.Length == 0) return;

        var currentTarget = waypoints[currentWaypoint].position;
        var moveDirection = currentTarget - transform.position;
        var moveAmount = speed * Time.deltaTime;

        if (moveDirection.magnitude <= moveAmount)
        {
            // Reached the current waypoint
            if (currentWaypoint == waypoints.Length - 1)
            {
                // Reached the final waypoint, start over
                currentWaypoint = 0;
            }
            else
            {
                // Move to the next waypoint
                currentWaypoint++;
            }

            // Start waiting at the current waypoint
            StartCoroutine(WaitAtWaypoint());
        }
        else
        {
            // Move towards the current waypoint
            transform.position += moveDirection.normalized * moveAmount;
        }

        

        // Update the animation
        Vector3 velocity = moveDirection.normalized * speed;
        animator.SetBool("idle", velocity == Vector3.zero);

        //Flip
        if (velocity.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        } else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    IEnumerator WaitAtWaypoint()
    {
        waitTime = Random.Range(2, 5);
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        isWaiting = false;
    }
}
