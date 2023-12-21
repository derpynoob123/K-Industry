using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelector
{
    public Tile SelectedTile { get; private set; }
    public event Action Selected;
    public event Action Deselected;

    public void SelectTile(Tile tile)
    {
        SelectedTile = tile;
        Selected.Invoke();
    }

    public void Deselect()
    {
        SelectedTile = null;
        Deselected.Invoke();
    }
}
