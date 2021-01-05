using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] string name;
    public Group group;

    void Start()
    {
        group.player = this;
    }

    public void CommenceFigure(Figure figure)
    {
        GameManager manager = GameObject.Find("Board").GetComponent<GameManager>();
        manager.Commence(figure);
    }

    public void ReturnFigure(Figure figure)
    {
        GameManager manager = GameObject.Find("Board").GetComponent<GameManager>();
        
        manager.Return(figure);
    }

    public void MoveForward(Figure figure, int steps)
    {
        GameManager manager = GameObject.Find("Board").GetComponent<GameManager>();
        manager.Move(figure, steps);
    }

    public void ReceiveFigure(Figure figure)
    {
        
        if (figure.inSlot == true)
        {
            CommenceFigure(figure);
        }

        else if(figure.inSlot == false)
        {
            int value = Random.Range(1,6);
            MoveForward(figure, 69);
        }
    }
}
