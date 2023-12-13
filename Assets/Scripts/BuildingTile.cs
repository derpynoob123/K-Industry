using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTile
{
    public bool Occupied { get; set; }
    public Vector2Int Position { get; }

    public BuildingTile(Vector2Int position)
    {
        Position = position;
    }
}
