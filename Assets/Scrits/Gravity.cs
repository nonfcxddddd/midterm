using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Gravity : MonoBehaviour
{
    Rigidbody rb;
    const float G =0.006743f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void FixedUpdate()
    {
        throw new NotImplementedException();
    }

    
    void Attract(Gravity other)
    {
        Rigidbody rbother = GetComponent<Rigidbody>();

        Vector3 direction = rb.position - other.rb.position;
        float distance = direction.magnitude;

        if (distance ==0)
        {
            return;
        }

        float foceMagnitude = G * (rb.mass * other.rb.mass) / Mathf.Pow(distance, 2);
        Vector3 force = foceMagnitude * direction.normalized;
    }
}
