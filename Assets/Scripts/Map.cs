using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefab;
    [SerializeField]
    private Grid grid;

    private readonly List<GameObject> tiles = new();
    public List<BuildingTile> BuildingTiles { get; set; }

    private void Start()
    {
        BuildingTiles = new();
        InitialiseGrid();
    }

    private void InitialiseGrid()
    {
        int rowLength = 8;
        int columnLength = 8;
        for (int row = 0; row < rowLength; row++)
        {
            for (int column = 0; column < columnLength; column++)
            {
                var position = new Vector3Int(row, column);
                var worldPosition = grid.GetCellCenterWorld(position);
                var tile = Instantiate(tilePrefab, worldPosition, Quaternion.identity);
                tiles.Add(tile);
                var gridPosition = new Vector2Int(row, column);
                var buildingTile = new BuildingTile(gridPosition);
                BuildingTiles.Add(buildingTile);
            }
        }
    }

    public void ChangeAllTileColourToGreen()
    {
        for (int tileIndex = 0; tileIndex < tiles.Count; tileIndex++)
        {
            var tileRenderer = tiles[tileIndex].GetComponent<SpriteRenderer>();
            tileRenderer.color = Color.green;
        }
    }

    public void ChangeAllTileColourToWhite()
    {
        for (int tileIndex = 0; tileIndex < tiles.Count; tileIndex++)
        {
            var tileRenderer = tiles[tileIndex].GetComponent<SpriteRenderer>();
            tileRenderer.color = Color.white;
        }
    }
}
