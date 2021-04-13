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
    [SerializeField] private Vector3 slotRotation;
    [SerializeField] private Vector3 setup;

    private List<string> souls;

    void Start()
    {
        transform.localPosition = setup;
        transform.localEulerAngles = slotRotation;
    }

    public Vector3 GiveSlotRotation()
    {
        return slotRotation;
    }

    public void AddSoul()
    {

    }

}