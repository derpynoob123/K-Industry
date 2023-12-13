using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public Dictionary<Vector2Int, Tile> Tiles { get; set; }

    public Map()
    {
        Tiles = new();
    }

    public Tile GetTile(Vector2Int tilePosition)
    {
        return Tiles[tilePosition];
    }
}
