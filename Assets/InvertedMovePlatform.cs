using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertedMovePlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int curentWaypoint = 0;

    public float speed = 1f;

    private void Update()
    {
        if (Vector2.Distance(waypoints[curentWaypoint].transform.position, transform.position) < 0.1f)
        {
            curentWaypoint++;
            if (curentWaypoint >= waypoints.Length)
            {
                curentWaypoint = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[curentWaypoint].transform.position, speed * Time.deltaTime);




    }
}
