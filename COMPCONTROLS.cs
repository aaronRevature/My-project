
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompControls : MonoBehaviour
{

    private Vector2 target;
    public float speed;

    public float turnSpeed;

    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        StartCoroutine(destroyAfterTime());

    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);

    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "wall")
        {
            Destroy(gameObject);

        }
    }


    IEnumerator destroyAfterTime()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}