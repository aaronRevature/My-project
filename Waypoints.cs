using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class Waypoints : MonoBehaviour
{
    [SerializeField]
    public GameObject gameObjects; 
    [SerializeField]
    public GameObject[] waypoints;
    [SerializeField]
    float moveSpeed = 4;
    public int current = 0;
    public int WpRadius = 9;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WpRadius)
        
            current++;
            if (current > waypoints.Length)
            {
                current = 0;
            }
            transform.position = Vector3.MoveTowards(transform.position,
                waypoints[current].transform.position,
                Time.deltaTime * moveSpeed);
        
        }
    }
