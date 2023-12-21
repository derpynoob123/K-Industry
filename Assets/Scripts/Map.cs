using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public Dictionary<Vector3Int, Tile> Tiles { get; }

    public Map()
    {
        Tiles = new();
    }

    public void InitialiseTile(Vector3Int tileGridPosition, Transform tileTransform)
    {
        Tile tile = new(tileGridPosition)
        {
            TileTransform = tileTransform
        };
        Tiles.Add(tileGridPosition, tile);
    }

    public Tile GetTile(Vector3Int tilePosition)
    {
        return Tiles[tilePosition];
    }
}
