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
        List<Vector3Int> tilePositions = new();
        for (int tileIndex = 0; tileIndex < tiles.Length; tileIndex++)
        {
            Vector3 worldPosition = tiles[tileIndex].position;
            Vector3Int gridPosition = grid.WorldToCell(worldPosition);
            tilePositions.Add(gridPosition);
        }
        map.InitialiseTiles(tilePositions.ToArray());
    }

    public Dictionary<Vector3Int, Tile> GetTiles()
    {
        return map.Tiles;
    }
}
