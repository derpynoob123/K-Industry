using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public Vector3Int GridSpacePosition { get; }
    public Transform TileTransform { get; set; } 

    public Tile(Vector3Int position)
    {
        GridSpacePosition = position;
    }
}
