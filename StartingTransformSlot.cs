using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingTransformSlot : MonoBehaviour
{
    public Transform Transform;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = Transform.position;
        gameObject.transform.rotation = Transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
