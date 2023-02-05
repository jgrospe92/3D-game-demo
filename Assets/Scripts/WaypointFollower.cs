using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    // reference for multiple gameobjects
    [SerializeField] GameObject[] waypoints;
    // index of active waypoint
    int currentWaypointIndex = 0;

    [SerializeField] float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        // Checks the distance between the platform position to the waypoint pos
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) <= 0f)
        {
            // increment the waypoint index
            currentWaypointIndex++;
            // if the currentwaypoint is greater or equal to the size of the array
            // reset it back to 0;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        // refer to this; it get the gameobject transform 
        transform.position = Vector3.MoveTowards(transform.position,
            waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }
}
