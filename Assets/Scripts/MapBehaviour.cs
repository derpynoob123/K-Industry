using System.Collections;
using System.Collections.Generic;
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

    public Dictionary<Vector3Int, Tile> GetTiles()
    {
        return map.Tiles;
    }
}
