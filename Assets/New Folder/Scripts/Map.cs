using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public Dictionary<Transform, Tile> Tiles { get; }

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
        Tiles.Add(tileTransform, tile);
    }

    public Tile GetTile(Transform tileTransform)
    {
        return Tiles[tileTransform];
    }
}
