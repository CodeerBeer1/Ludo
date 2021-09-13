using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] List<Player> players;
    private GameCamera camera;
    public Player active;
    void Start()
    {
        camera = GameObject.Find("Camera").GetComponent<GameCamera>();
        for(int i = 0; i < active.group.figures.Count; i++)
        {
            active.group.figures[i].clickable = true;
        }

        SwitchTurn();
    }

    public void SwitchTurn()
    {
        for (int i = 0; i < 3; i++)
        {
            if (players[i].isActive == true)
            {
                active = players[i];
            }
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

                    SwitchTurn();
                        
                }
                   
            }
        }
    }
    
}

