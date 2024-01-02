using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelectorBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject selectedTile;

    private readonly Selector<Tile> tileSelector = new();

    public void SelectTile(Tile tile)
    {
        tileSelector.Select(tile);
        selectedTile = tileSelector.SelectedObject.TileTransform.gameObject;
    }

    public void Deselect()
    {
        tileSelector.Deselect();
        selectedTile = null;
    }

    public Tile GetSelectedTile()
    {
        return tileSelector.SelectedObject;
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
