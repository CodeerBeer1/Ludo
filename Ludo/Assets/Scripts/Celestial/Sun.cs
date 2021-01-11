using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    float x = 1.01f;

    void Update()
    {

        transform.rotation *= Quaternion.Euler(x, 0, 0);
        //RenderSettings.skybox.SetFloat("_Rotation", Time.deltaTime);

    }

}
