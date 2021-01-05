using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Group : MonoBehaviour
{
    public Player player;
    [SerializeField] string name;
    public List<Figure> figures;
    public List<Tile> path;
    public int slotRotation;

    private List<string> souls;

    public void AddSoul()
    {

    }

}