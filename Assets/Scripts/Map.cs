using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public Dictionary<Vector3Int, Tile> Tiles { get; set; }

    public Map()
    {
        Tiles = new();
    }

    public void InitialiseTiles(Vector3Int[] tilePositions)
    {
        for (int tileIndex = 0; tileIndex < tilePositions.Length; tileIndex++)
        {
            Vector3Int position = tilePositions[tileIndex];
            Tile tile = new(position);
            Tiles.Add(position, tile);
        }
    }

    public Tile GetTile(Vector3Int tilePosition)
    {
        return Tiles[tilePosition];
    }
}
