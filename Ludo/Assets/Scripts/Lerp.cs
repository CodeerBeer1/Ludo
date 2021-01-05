using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    public Material material;
    [SerializeField] [Range(0f, 10f)] float lerpTime;
    [SerializeField] Color[] color;

    int colorIndex = 0;
    float t = 0f;
    int length;

    void Start()
    {

    }
    void Update()
    {
        LerpColor();
    }

    void LerpColor()
    {
        material.color = Color.Lerp(material.color, color[colorIndex], lerpTime * Time.deltaTime);
        t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);
        length = color.Length;


        if (t > 0.9f)
        {
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= length) ? 0 : colorIndex;
        }
    }

    public Color[] GiveColors()
    {
        return color;
    }

}
