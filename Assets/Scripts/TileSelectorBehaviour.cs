using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelectorBehaviour : MonoBehaviour
{
    private TileSelector tileSelector = new();

    public void SelectTile(Tile tile)
    {
        tileSelector.SelectedTile = tile;
    }
}
