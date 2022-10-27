using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHumanoids : MonoBehaviour
{
    public GameObject Humanoid;
    public List<GameObject>Humanoids;
    public float SecondsBetweenSpawn;
    public float TimePassed;
   [SerializeField]GameObject Spawn;
    public float Seconds;
    void Start()
    {
        
        Humanoids = new List<GameObject>();
        TimePassed += Seconds* Time.deltaTime;
        

    }

    // Update is called once per frame
    void Update()
    {

        if (SecondsBetweenSpawn > TimePassed)
        {
            for (int i = 0; i < Humanoids.Count; i++)
                Instantiate(Humanoid, transform.position, transform.rotation);
            TimePassed = 0f;

        }
    }
        
}
