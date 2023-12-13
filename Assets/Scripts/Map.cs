using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefab;
    [SerializeField]
    private Grid grid;

    public List<GameObject> Tiles { get; set; }

    private void Start()
    {
        Tiles = new();
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
                Tiles.Add(tile);
            }
        }
    }

    public void ChangeAllTileColourToGreen()
    {
        for (int tileIndex = 0; tileIndex < Tiles.Count; tileIndex++)
        {
            var tileRenderer = Tiles[tileIndex].GetComponent<SpriteRenderer>();
            tileRenderer.color = Color.green;
        }
    }

    public void ChangeAllTileColourToWhite()
    {
        for (int tileIndex = 0; tileIndex < Tiles.Count; tileIndex++)
        {
            var tileRenderer = Tiles[tileIndex].GetComponent<SpriteRenderer>();
            tileRenderer.color = Color.white;
        }
    }
}
