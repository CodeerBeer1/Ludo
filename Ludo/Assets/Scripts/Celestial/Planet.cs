using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    void Start()
    {

    }
    void Update()
    {
        transform.eulerAngles += new Vector3(0, 0, 0.01f);
    }

}
