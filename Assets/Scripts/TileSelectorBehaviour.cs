using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelectorBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject SelectedTileIcon;

    private readonly TileSelector tileSelector = new();

    public void SelectTile(Tile tile)
    {
        tileSelector.SelectedTile = tile;
    }

    private void HighlightTile()
    {
        
    }
}
