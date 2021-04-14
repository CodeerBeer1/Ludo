using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCamera : MonoBehaviour
{
    [SerializeField] private GameObject board;
    [SerializeField] private GameObject cameraControl;
    bool clickable = true;
    bool transtition = false;

    void Start()
    {
        Top();
        
    }

    public IEnumerator RotateCameraControl(float rotation)
    {
        Quaternion euler = Quaternion.Euler(0,0,rotation);
        GameObject[] letters = GameObject.FindGameObjectsWithTag("direction");

        while (cameraControl.transform.rotation != euler)
        {
            cameraControl.transform.rotation = Quaternion.RotateTowards(cameraControl.transform.rotation, euler, Time.deltaTime * 350);
            for(int i = 0; i < letters.Length; i++)
            {
                letters[i].transform.rotation = Quaternion.Euler(0,0,0);
            }
            yield return null;
        }
    }

    public IEnumerator SetViewAngle(float x, float y, float z, int speed, Vector3 up, Vector3 forward)
    {            
        while (transform.localPosition != new Vector3(x, y, z))
        {
            print("doing");

            transtition = true;
            clickable = false;

            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(x, y, z), Time.deltaTime * speed);
            Quaternion rot = Quaternion.LookRotation(board.transform.position + up - transform.position, forward);
            transform.rotation = rot;

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
            transform.LookAt(figure.transform, board.transform.up);
            yield return null;
        }

        yield return new WaitForSeconds(2);

        transtition = false;
        cameraControl.SetActive(true);

        Top();

        figure.clickable = true;

    }

    public void Top()
    {
        if (clickable)
        {
            if (!transtition)
            StartCoroutine(SetViewAngle(0, 18, 0, 40, board.transform.up, board.transform.forward));
            StartCoroutine(RotateCameraControl(0));
        }

    }

   public void Blue()
    {
        if (clickable)
        {
            if (!transtition)
            StartCoroutine(SetViewAngle(-0.5f, 10, -0.5f, 40, board.transform.up, board.transform.up));
            StartCoroutine(RotateCameraControl(45));

        }

    }
    
    public void Red()
    {
        if (clickable)
        {
            if (!transtition)
            StartCoroutine(SetViewAngle(-0.5f, 10, 0.5f, 40, board.transform.up, board.transform.up));
            StartCoroutine(RotateCameraControl(135));
        }

    }
    
    public void Green()
    {
        if (clickable)
        {
            if (!transtition)
            StartCoroutine(SetViewAngle(0.5f, 10, 0.5f, 40, board.transform.up, board.transform.up));
            StartCoroutine(RotateCameraControl(-135));
        }

    }


    public void Pink()
    {
        if (clickable)
        {
            if (!transtition)
            StartCoroutine(SetViewAngle(0.5f, 10, -0.5f, 40, board.transform.up, board.transform.up));
            StartCoroutine(RotateCameraControl(315));
        }

    }
    /*
    public void South()
    {
        if (clickable)
        {
            if (!transtition)
            StartCoroutine(SetViewAngle(5, 6, -1.5f, Quaternion.Euler(45, 0, 0), 700));
            StartCoroutine(RotateCameraControl(0));
        }
        
    }

    public void West()
    {
        if (clickable)
        {
            if (!transtition)
            StartCoroutine(SetViewAngle(-2.5f, 6, 6, Quaternion.Euler(45, 90, 0), 700));
            StartCoroutine(RotateCameraControl(90));
        }
        
    }

    public void North()
    {
        if (clickable)
        {
            if (!transtition)
            StartCoroutine(SetViewAngle(5, 6, 13.5f, Quaternion.Euler(45, 180, 0), 700));
            StartCoroutine(RotateCameraControl(180));
        }
        
    }

    public void East()
    {
        if (clickable)
        {
            if (!transtition)
            StartCoroutine(SetViewAngle(12.5f, 6, 6, Quaternion.Euler(45, 270, 0), 700));
            StartCoroutine(RotateCameraControl(-90));
        }
        
    }*/
}