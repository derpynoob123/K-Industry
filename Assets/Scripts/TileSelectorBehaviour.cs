using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelectorBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform selectedTileIcon;

    private readonly TileSelector tileSelector = new();

    private void Awake()
    {
        RemoveHighlight();
    }

    public void SelectTile(Tile tile)
    {
        tileSelector.SelectedTile = tile;
        HighlightTile(tile);
    }

    public void Deselect()
    {
        tileSelector.SelectedTile = null;
        RemoveHighlight();
    }

    private void HighlightTile(Tile tile)
    {
        selectedTileIcon.gameObject.SetActive(true);
        selectedTileIcon.position = tile.TileTransform.position;
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
