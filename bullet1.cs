 using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bullet1 : MonoBehaviour
{
    public Vector3 V;
    private Vector2 target;
    public float speed;
    public float timer;

    public float turnSpeed;
    private float time;
    private GameObject instantiatedObj;
    private GameObject Bullet1;
    private Rigidbody RBE;
    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RBE = Bullet1.GetComponent<Rigidbody>();

    }
  
    

    void Update()

    {
        


        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        RBE.AddForce(new Vector3(2000, 20000, 0));


        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
    }


  





void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Destroy(this.Bullet1);

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.Bullet1);
    }


}