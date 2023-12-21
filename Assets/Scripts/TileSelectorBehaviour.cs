using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelectorBehaviour : MonoBehaviour
{
    [SerializeField]
    private FacilitySelectionDropdown facilitySelectionDropdown;
    [SerializeField]
    private TileSelectionHighlight tileSelectionHighlight;

    private readonly TileSelector tileSelector = new();

    private void Awake()
    {
        tileSelector.Selected += tileSelectionHighlight.HighlightSelectedTile;
        tileSelector.Selected += facilitySelectionDropdown.ShowDropdown;
        tileSelector.Deselected += tileSelectionHighlight.RemoveHighlight;
        tileSelector.Deselected += facilitySelectionDropdown.HideDropdown;
    }

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
