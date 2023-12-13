using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public Vector2Int GridPosition { get; }

    public Tile(Vector2Int position)
    {
        GridPosition = position;
    }
}
