using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{

    bool transtition = false;
    void Start()
    {
        StartCoroutine(SetViewAngle(5, 9, 6, Quaternion.Euler(90, 0, 0), 350));
    }

    public IEnumerator SetViewAngle(float x, float y, float z, Quaternion rotation, int speed)
    {
        while (transform.position != new Vector3(x, y, z))
        {
            transtition = true;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(x, y, z), Time.deltaTime * 25);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime * speed);
            yield return null;
        }
        transtition = false;

    }

    public IEnumerator FollowFigure(Figure figure)
    {

        if (figure.group.name == "Blue")
        {
            transform.position = figure.transform.position - figure.transform.right;
            while (figure.moving)
            {
                transform.position = figure.transform.position;
               // transform.position = figure.transform.position + figure.transform.up;
                transform.LookAt(figure.transform);
                print("dd");
                yield return null;
            }
        }

        if (figure.group.name == "Red")
        {
            transform.rotation = figure.transform.rotation;
            transform.eulerAngles += new Vector3(30, 45, 0);
            while (figure.moving)
            {
                transform.position = figure.transform.position + new Vector3(-0.75f, 0.75f, 0.75f);

                yield return null;
            }
        }
        yield return new WaitForSeconds(2);
        Top();
        
        
    }

    public void Top()
    {
        if (!transtition)
        StartCoroutine(SetViewAngle(5, 9, 6, Quaternion.Euler(90, 0, 0), 700));
    }

    public void Blue()
    {
        if (!transtition)
        StartCoroutine(SetViewAngle(-1.5f, 3, -0.5f, Quaternion.Euler(160, -135, 180), 350));
    }

    public void Red()
    {
        if (!transtition)
        StartCoroutine(SetViewAngle(-1.5f, 3, 12.5f, Quaternion.Euler(160, 315, 180), 350));
    }

    public void Green()
    {
        if (!transtition)
        StartCoroutine(SetViewAngle(11.5f, 3, 12.5f, Quaternion.Euler(160, -315, 180), 350));
    }

    public void Pink()
    {
        if (!transtition)
        StartCoroutine(SetViewAngle(11.5f, 3, -0.5f, Quaternion.Euler(160, 135, 180), 350));
    }

    public void South()
    {
        if (!transtition)
        StartCoroutine(SetViewAngle(5, 6, -1.5f, Quaternion.Euler(45, 0, 0), 700));
    }

    public void West()
    {
        if (!transtition)
        StartCoroutine(SetViewAngle(-2.5f, 6, 6, Quaternion.Euler(45, 90, 0), 700));
    }

    public void North()
    {
        if (!transtition)
            StartCoroutine(SetViewAngle(5, 6, 13.5f, Quaternion.Euler(45, 180, 0), 700));
    }

    public void East()
    {
        if (!transtition)
            StartCoroutine(SetViewAngle(12.5f, 6, 6, Quaternion.Euler(45, -90, 0), 700));
    }
}