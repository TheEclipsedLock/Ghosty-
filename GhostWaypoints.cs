using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostWaypoints : MonoBehaviour
{
    //Array of waypoints and their corresponding transforms within
    public GameObject[] waypoints;

    public GameObject ghost;

    //Where we are currently going
    public int currentWaypoint;

    //Rotates toward waypoint
    public float rotationSpeed;

    //Speed to get to the next gameObject
    public float speed;

    //A "close-enough" value so that the gameObject can get to its approximate location and go to the next
    public float waypointRadius = 1;

    private void Update()
    {
        if(Vector3.Distance(waypoints[currentWaypoint].transform.position, ghost.transform.position) < waypointRadius)
        {
            //We are within the radius of the waypoint. Move to the next one.

            currentWaypoint = currentWaypoint + 1;
            if(currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }

            ghost.transform.Rotate(0, 90, 0, Space.World);
        }
        ghost.transform.position = Vector3.MoveTowards(ghost.transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * speed);
    }
}
