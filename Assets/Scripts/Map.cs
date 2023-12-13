using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public Dictionary<Vector2Int, Tile> Tiles { get; set; }

    private readonly int rowLength = 0;
    private readonly int columnLength = 0;

    public Map(int rowLength, int columnLength)
    {
        this.rowLength = rowLength;
        this.columnLength = columnLength;
    }

    public void InitialiseGrid()
    {
        for (int row = 0; row < rowLength; row++)
        {
            for (int column = 0; column < columnLength; column++)
            {
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
}
