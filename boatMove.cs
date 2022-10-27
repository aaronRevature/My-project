using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatMove : MonoBehaviour
{
    
    void MoveForward()
    {
        transform.position += 20 * transform.right * Time.deltaTime;
    }
    
    void Update()
    {
        MoveForward();
    }
}
