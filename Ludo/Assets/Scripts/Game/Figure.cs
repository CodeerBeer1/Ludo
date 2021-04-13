using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Figure : MonoBehaviour
{
    public Group group;
    public GameObject figure;
    [SerializeField] GameObject slot;
    public int currentPosition;
    public bool inSlot;
    public Animator animation;
    public bool clickable;
    public bool moving = false;

    void Start()
    {
        inSlot = true;
        transform.localPosition = slot.transform.localPosition + new Vector3(0, 4, 0);
        currentPosition = 0;
        animation.Play("Skeleton|Idle");

    }


    void OnMouseDown()
    {
        group.player.ReceiveFigure(this);
    }

    public int GiveIndex()
    {
        return group.figures.IndexOf(this);
    }

    public void MoveToStart()
    {
        inSlot = false;
        currentPosition = 0;
        transform.Rotate(0, -40, 0);
        transform.parent = group.path[0].transform;
        transform.localPosition = new Vector3(0, group.path[0].offsetValue, 0);

        group.path[0].AddOccupier(this);
    }

    public void MoveToSlot()
    {
        group.path[currentPosition].RemoveOccupier(this);
        inSlot = true;
        transform.parent = slot.transform;
        transform.localPosition = slot.transform.localPosition + new Vector3(0, 4, 0);
        //transform.localEulerAngles = ;
        currentPosition = 0;
    }

    public void Forward(int steps)
    {
        moving = true;
        clickable = false;

        int centerDistance = (group.path.Count) - currentPosition;
        GameObject center = GameObject.Find("Center");
        if(inSlot != true)
        {
            if(steps <= centerDistance)
            {
                if(steps > 0)
                {
                    if(centerDistance == 1)
                    {
                        group.path[currentPosition].RemoveOccupier(this);
                        StartCoroutine(MoveToCenter(center));
                    }

                    else
                    {
                        group.path[currentPosition].RemoveOccupier(this);
                        currentPosition ++;
                        transform.parent = group.path[currentPosition].transform;
                        StartCoroutine(MoveFigure(currentPosition, steps));
                        
                        group.path[currentPosition].AddOccupier(this);
                    }
                    
                }
                else
                {
                    animation.Play("Skeleton|Idle");
                    moving = false;
                }
            }
        }

    }

    IEnumerator MoveFigure(int position, int steps)
    {
        animation.Play("Skeleton|Walking");
        float offset = group.path[position].offsetValue;
        while(transform.localPosition != new Vector3(0, group.path[position].offsetValue, 0))
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(0, group.path[position].offsetValue, 0), Time.deltaTime * 5f);
            yield return null;
        }

        if(position == 62)
        {
            transform.Rotate(0, 90, 0);
        }

        else
        {
            transform.Rotate(0, group.path[position].rotateValue, 0);
        }

        steps--;
        Forward(steps);
    }

    IEnumerator MoveToCenter(GameObject center)
    {
        animation.speed = 0;
        while (transform.position != center.transform.position + new Vector3(0, 0.2f, 0))
        {
            transform.position = Vector3.MoveTowards(transform.position, center.transform.position + new Vector3(0, 0.2f, 0), Time.deltaTime * 0.6f);
            yield return null;
        }
        group.figures.Remove(this);
        Destroy(this.figure);
    }
}
