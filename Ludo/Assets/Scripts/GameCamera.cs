using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCamera : MonoBehaviour
{

    [SerializeField] private GameObject cameraControl;
    bool clickable = true;
    bool transtition = false;
    void Start()
    {
        StartCoroutine(SetViewAngle(5, 9, 6, Quaternion.Euler(-90, 0, 0), 350));
    }

    public IEnumerator RotateCameraControl(float rotation)
    {
        Quaternion euler = Quaternion.Euler(0,0,rotation);

        while (cameraControl.transform.rotation != euler)
        {
            cameraControl.transform.rotation = Quaternion.RotateTowards(cameraControl.transform.rotation, euler, Time.deltaTime * 350);

            yield return null;
        }
    }

    public IEnumerator SetViewAngle(float x, float y, float z, Quaternion rotation, int speed)
    {
        while (transform.position != new Vector3(x, y, z))
        {
            transtition = true;
            clickable = false;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(x, y, z), Time.deltaTime * 25);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime * speed);
            yield return null;
        }
        transtition = false;
        clickable = true;
    }

    public IEnumerator FollowFigure(Figure figure)
    {
        cameraControl.SetActive(false);
        transtition = true;

        Vector3 right = -figure.transform.right;
        Vector3 forward = -figure.transform.forward;
        Vector3 up = figure.transform.up;

        Vector3 offset = right + up + forward;

        while (figure.moving)
        {
            transform.position = figure.transform.position + offset;
            transform.LookAt(figure.transform);
            yield return null;
        }
        yield return new WaitForSeconds(2);
        transtition = false;
        Top();
        cameraControl.SetActive(true);
        figure.clickable = true;

    }

    public void Top()
    {
        if (clickable)
        {
            if (!transtition)
                print("going");
                    StartCoroutine(SetViewAngle(5, 9, 6, Quaternion.Euler(90, 0, 0), 700));
                    StartCoroutine(RotateCameraControl(90));
        }
        
    }

    public void Blue()
    {
        if (clickable)
        {
            if (!transtition)
                print("going");
            StartCoroutine(SetViewAngle(-1.5f, 3, -0.5f, Quaternion.Euler(160, -135, 180), 350));
                    StartCoroutine(RotateCameraControl(135));
        }
        
    }

    public void Red()
    {
        if (clickable)
        {
            if (!transtition)
                print("going");
            StartCoroutine(SetViewAngle(-1.5f, 3, 12.5f, Quaternion.Euler(160, 315, 180), 350));
                    StartCoroutine(RotateCameraControl(225));
        }
            
    }

    public void Green()
    {
        if (clickable)
        {
            if (!transtition)
                print("going");
            StartCoroutine(SetViewAngle(11.5f, 3, 12.5f, Quaternion.Euler(160, -315, 180), 350));
                    StartCoroutine(RotateCameraControl(315));
        }
        
    }

    public void Pink()
    {
        if (clickable)
        {
            if (!transtition)
                print("going");
            StartCoroutine(SetViewAngle(11.5f, 3, -0.5f, Quaternion.Euler(160, 135, 180), 350));
                    StartCoroutine(RotateCameraControl(45));
        }
        
    }

    public void South()
    {
        if (clickable)
        {
            if (!transtition)
                print("going");
            StartCoroutine(SetViewAngle(5, 6, -1.5f, Quaternion.Euler(45, 0, 0), 700));
                    StartCoroutine(RotateCameraControl(90));
        }
        
    }

    public void West()
    {
        if (clickable)
        {
            if (!transtition)
                print("going");
            StartCoroutine(SetViewAngle(-2.5f, 6, 6, Quaternion.Euler(45, 90, 0), 700));
                    StartCoroutine(RotateCameraControl(180));
        }
        
    }

    public void North()
    {
        if (clickable)
        {
            if (!transtition)
                print("going");
            StartCoroutine(SetViewAngle(5, 6, 13.5f, Quaternion.Euler(45, 180, 0), 700));
                    StartCoroutine(RotateCameraControl(270));
        }
        
    }

    public void East()
    {
        if (clickable)
        {
            if (!transtition)
                print("going");
            StartCoroutine(SetViewAngle(12.5f, 6, 6, Quaternion.Euler(45, -90, 0), 700));
                    StartCoroutine(RotateCameraControl(360));
        }
        
    }
}