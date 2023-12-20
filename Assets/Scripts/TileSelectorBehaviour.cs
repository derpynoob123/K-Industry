using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelectorBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform selectedTileIcon;

    private readonly TileSelector tileSelector = new();

    public void SelectTile(Tile tile)
    {
        tileSelector.SelectedTile = tile;
        HighlightTile(tile);
    }

    private void HighlightTile(Tile tile)
    {
        selectedTileIcon.position = tile.TileTransform.position;
    }

    public Tile GetSelectedTile()
    {
        return tileSelector.SelectedTile;
    }
}
