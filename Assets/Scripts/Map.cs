using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public Dictionary<Vector2, Tile> Tiles { get; set; }

    public Map()
    {
        Tiles = new();
    }

    public void ReadTiles(GameObject container)
    {
        Transform[] tileTransforms = container.GetComponentsInChildren<Transform>();
        for (int tileIndex = 0; tileIndex < tileTransforms.Length; tileIndex++)
        {
            Vector3 worldPosition = tileTransforms[tileIndex].transform.position;
            float posX = worldPosition.x;
            float posY = worldPosition.y;
            Vector2 position = new Vector2(posX, posY);
            Tile tile = new(position);
            Tiles.Add(position, tile);
        }
    }

    public Tile GetTile(Vector2 tilePosition)
    {
        return Tiles[tilePosition];
    }
}
