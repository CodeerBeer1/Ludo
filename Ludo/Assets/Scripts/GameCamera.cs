using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{

    bool transtition = false;
    void Start()
    {
        StartCoroutine(SetViewAngle(5, 9, 6, Quaternion.Euler(90, 0, 0)));
    }

    public IEnumerator SetViewAngle(float x, float y, float z, Quaternion rotation)
    {
        while (transform.position != new Vector3(x, y, z))
        {
            transtition = true;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(x, y, z), Time.deltaTime * 25);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime * 350);
            yield return null;
        }
        transtition = false;

    }

    public IEnumerator FollowFigure(Figure figure)
    {
        transform.rotation = figure.transform.rotation;
        transform.eulerAngles += new Vector3(30, 45, 0);

        if (figure.group.name == "Blue")
        {
            print("blue");
            while (true)
            {
                transform.position = figure.transform.position + new Vector3(-0.75f, 0.75f, -0.75f);

                yield return null;
            }
        }

        if (figure.group.name == "Red")
        {
            print("red");
            while (true)
            {
                transform.position = figure.transform.position + new Vector3(-0.75f, 0.75f, 0.75f);

                yield return null;
            }
        }
        
        
    }

    public void Top()
    {
        if (!transtition)

            StartCoroutine(SetViewAngle(5, 9, 6, Quaternion.Euler(90, 0, 0)));
    }

    public void Blue()
    {
        if (!transtition)

            StartCoroutine(SetViewAngle(-1.5f, 3, -0.5f, Quaternion.Euler(160, -135, 180)));
    }

    public void Red()
    {
        if (!transtition)

            StartCoroutine(SetViewAngle(-1.5f, 3, 12.5f, Quaternion.Euler(160, 315, 180)));
    }

    public void Green()
    {
        if (!transtition)

            StartCoroutine(SetViewAngle(11.5f, 3, 12.5f, Quaternion.Euler(160, -315, 180)));
    }

    public void Pink()
    {
        if (!transtition)

            StartCoroutine(SetViewAngle(11.5f, 3, -0.5f, Quaternion.Euler(160, 135, 180)));
    }
}