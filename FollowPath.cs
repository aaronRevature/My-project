using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{

    [SerializeField] private Transform[] Waypoints;
    private float moveSpeed = 2f;
    private int WaypointIndex = 0;
    private void Start()
    {
        transform.position = Waypoints[WaypointIndex].transform.position;

    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if (WaypointIndex <= Waypoints.Length - 1)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                Waypoints[WaypointIndex].transform.position,
                moveSpeed * Time.deltaTime);

            if (transform.position == Waypoints[WaypointIndex].transform.position)
            {
                WaypointIndex += 1;
            }
        }
        if(WaypointIndex > Waypoints.Length - 1)
        {
            WaypointIndex = 1;
        }
    }
}