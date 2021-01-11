using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public Rigidbody rb;





    void Attract(Attractor attractedObject)
    {
        Rigidbody objectRb = attractedObject.rb;

        Vector3 direction = rb.position - objectRb.position;
        
        float distance = direction.magnitude;
        
        float forceMagnitude = (rb.mass* objectRb.mass) / Mathf.Pow(distance, 2);
        
        Vector3 force = direction.normalized * forceMagnitude;
        objectRb.AddForce(force);
    }
    void Update()
    {
        Attractor[] planetoids = FindObjectsOfType<Attractor>();

        foreach (Attractor planetoid in planetoids)
        {
            if(planetoid != this)
            {
                Attract(planetoid);
            }
        }

    }
}
