using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public List<Figure> occupiers;
    public float offsetValue;
    public float rotateValue;

    public void AddOccupier(Figure occupier)
    {
        occupiers.Add(occupier);
        offset(true);
    }

    public void RemoveOccupier(Figure occupier)
    {
        offset(false);
        occupiers.Remove(occupier);
    }

    public void offset(bool add)
    {
        if(add == true)
        {
            for(int i = occupiers.Count-1; i > 1; i--)
            {
                occupiers[i].transform.position += new Vector3(0, 0.80f, 0);
            }
        }

        if (add == false)
        {
            for (int i = occupiers.Count -1; 0 > 1; i--)
            {
                occupiers[i].transform.position -= new Vector3(0, 0.80f, 0);
            }
        }
    }
}
