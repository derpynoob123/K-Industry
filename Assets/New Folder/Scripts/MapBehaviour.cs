using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefab;
    [SerializeField]
    private Transform[] tiles;
    [SerializeField]
    private Grid grid;

    private readonly Map map = new();

    private void Awake()
    {
        InitialiseMapTiles();
    }

    private void InitialiseMapTiles()
    {
        for (int tileIndex = 0; tileIndex < tiles.Length; tileIndex++)
        {
            Vector3 worldPosition = tiles[tileIndex].position;
            Vector3Int gridPosition = grid.WorldToCell(worldPosition);
            map.InitialiseTile(gridPosition, tiles[tileIndex]);
        }
    }

    public Tile[] GetTiles()
    {
        return map.Tiles.Values.ToArray();
    }

    public int GetTileCount()
    {
        return tiles.Length;
    }

    public Tile GetTile(Transform tileTransform)
    {
        return map.GetTile(tileTransform);
    }
}
