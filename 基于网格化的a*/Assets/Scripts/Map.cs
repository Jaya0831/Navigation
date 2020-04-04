using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    public Tilemap tilemap;
    
    // Start is called before the first frame update
    void Start()
    {
        tilemap.GetSprite(new Vector3Int(0, 0, 0));
        for (int i = -5; i < 5; i++)
        {
            for (int j = -5; j < 5; j++)
            {
                Debug.Log(tilemap.GetSprite(new Vector3Int(i, j, 0)));
            }
        }
    }
}
