using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefab;
    [SerializeField]
    private Grid grid;

    public Dictionary<Vector2Int, Tile> Tiles { get; set; }

    private readonly List<GameObject> tiles = new();
    private const int rowLength = 8;
    private const int columnLength = 8;

    private void Start()
    {
        Tiles = new();
        InitialiseGrid();
    }

    private void InitialiseGrid()
    {
        for (int row = 0; row < rowLength; row++)
        {
            for (int column = 0; column < columnLength; column++)
            {
                var position = new Vector3Int(row, column);
                var worldPosition = grid.GetCellCenterWorld(position);
                var tileGO = Instantiate(tilePrefab, worldPosition, Quaternion.identity);
                tiles.Add(tileGO);
                var gridPosition = new Vector2Int(row, column);
                var tile = new Tile(gridPosition);
                Tiles.Add(gridPosition ,tile);
            }
        }
    }

    public Tile GetTile(Vector2Int tilePosition)
    {
        return Tiles[tilePosition];
    }

    public void ChangeAllTileColourToGreen()
    {
        for (int tileIndex = 0; tileIndex < tiles.Count; tileIndex++)
        {
            var tileRenderer = tiles[tileIndex].GetComponentInChildren<SpriteRenderer>();
            tileRenderer.color = Color.green;
        }
    }

    public void ChangeAllTileColourToWhite()
    {
        for (int tileIndex = 0; tileIndex < tiles.Count; tileIndex++)
        {
            var tileRenderer = tiles[tileIndex].GetComponentInChildren<SpriteRenderer>();
            tileRenderer.color = Color.white;
        }
    }
}
