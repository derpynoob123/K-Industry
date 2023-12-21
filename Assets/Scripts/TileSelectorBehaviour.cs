using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelectorBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform selectedTileIcon;
    [SerializeField]
    private FacilitySelectionDropdown facilitySelectionDropdown;

    private readonly TileSelector tileSelector = new();

    private void Awake()
    {
        tileSelector.Selected += HighlightSelectedTile;
        tileSelector.Selected += facilitySelectionDropdown.ShowDropdown;
        tileSelector.Deselected += RemoveHighlight;
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

    private void HighlightSelectedTile()
    {
        selectedTileIcon.gameObject.SetActive(true);
        selectedTileIcon.position = tileSelector.SelectedTile.TileTransform.position;
    }

    private void RemoveHighlight()
    {
        selectedTileIcon.gameObject.SetActive(false);
    }

    public Tile GetSelectedTile()
    {
        return tileSelector.SelectedTile;
    }
}
