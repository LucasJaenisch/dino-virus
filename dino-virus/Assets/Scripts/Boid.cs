using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public float rotateSpeed;
    public GameObject target;

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Seek();
    }

    public void Seek()
    {
        Vector3 desired = new Vector3();

        desired = target.transform.position - transform.position;
        desired.Normalize();

        Vector3 rotateAmount = Vector3.Cross(desired, transform.forward);

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.forward * speed;

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        Debug.DrawRay(transform.position, transform.forward.normalized * 2, Color.green);
        Debug.DrawRay(transform.position, desired.normalized * 2, Color.magenta);
    }

}
