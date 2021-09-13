using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LerpUI : MonoBehaviour
{
    private Image img;
    GameObject center;
    [SerializeField] [Range(0f, 10f)] float lerpTime;
    [SerializeField] Color[] color;

    int colorIndex = 0;
    float t = 0f;
    int length;

    void Start()
    {
        img = GetComponent<Image>();
        center = GameObject.Find("Center");
        //color = center.GetComponent<Lerp>().GiveColors();


    }
    void Update()
    {
        LerpColor();
    }

    void LerpColor()
    {
        img.color = Color.Lerp(img.color, color[colorIndex], lerpTime * Time.deltaTime); 
        t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);
        length = color.Length;


        if (t > 0.9f)
        {
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= length) ? 0 : colorIndex;
        }
    }
}
