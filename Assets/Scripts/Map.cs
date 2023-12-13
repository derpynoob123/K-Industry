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

    public void InitialiseTiles(Transform[] tiles)
    {
        for (int tileIndex = 0; tileIndex < tiles.Length; tileIndex++)
        {
            Vector3 worldPosition = tiles[tileIndex].transform.position;
            int posX = (int) worldPosition.x;
            int  posY = (int) worldPosition.y;
            Vector3Int position = new Vector3Int(posX, posY);
            Tile tile = new(position);
            Tiles.Add(position, tile);
        }
    }

    public Tile GetTile(Vector3Int tilePosition)
    {
        return Tiles[tilePosition];
    }
}
