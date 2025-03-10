using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Gravity : MonoBehaviour
{
    Rigidbody rb;
    const float G =0.006743f;

    public static List<Gravity> otherObjectList;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (otherObjectList ==null)
        {
            otherObjectList = new List<Gravity>();
            
        }
        otherObjectList.Add(this);
    }

    private void FixedUpdate()
    {
        foreach (var obj in otherObjectList)
        {
            Attract(obj);
        }
    }

    
    void Attract(Gravity other)
    {

        Rigidbody rbother = other.rb;

        Vector3 direction = rb.position - other.rb.position;
        float distance = direction.magnitude;

        if (distance ==0)
        {
            return;
        }

        float foceMagnitude = G * (rb.mass * other.rb.mass) / Mathf.Pow(distance, 2);
        Vector3 force = foceMagnitude * direction.normalized;
        rbother.AddForce(force);
    }
}
