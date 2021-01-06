using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] List<Player> players;
    private Player active;
    private GameCamera camera;

    void Start()
    {

        camera = GameObject.Find("Camera").GetComponent<GameCamera>();
        active = players[0];
        for(int i = 0; i < active.group.figures.Count; i++)
        {
            active.group.figures[i].clickable = true;
        }
        
    }

    public Player GiveActivePlayer()
    {
        return active;
    }

    public void Commence(Figure figure)
    {
        if (figure.clickable)
        {
            if (active.group.name == figure.group.name)
            {
                if (figure.inSlot == true)
                    figure.MoveToStart();
            }
        }
    }

    public void Return(Figure figure)
    {
        if (figure.clickable)
        {
            if (active.group.name == figure.group.name)
            {
                if (figure.inSlot == true)
                    figure.MoveToSlot();
            }
        }
    }

    public void Move(Figure figure, int steps)
    {
        int centerDistance = (figure.group.path.Count) - figure.currentPosition;
        if (figure.clickable)
        {
            if (active.group.name == figure.group.name)
            {
                if (figure.inSlot != true)
                {
                    figure.Forward(steps);
                    if (steps <= centerDistance)
                    {
                        StartCoroutine(camera.FollowFigure(figure));
                    }
                        
                }
                   
            }
        }
    }
    
}

