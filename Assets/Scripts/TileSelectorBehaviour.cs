using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelectorBehaviour : MonoBehaviour
{
    private readonly TileSelector tileSelector = new();

    public void SelectTile(Tile tile)
    {
        tileSelector.SelectTile(tile);
    }

    public void Deselect()
    {
        tileSelector.Deselect();
    }

    public Tile GetSelectedTile()
    {
        return tileSelector.SelectedTile;
    }

    public void AddObserverToSelectedEvent(Action observer)
    {
        tileSelector.Selected += observer;
    }

    public void AddObserverToDeselectedEvent(Action observer)
    {
        tileSelector.Deselected += observer;
    }
}
