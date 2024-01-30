using System;
using UnityEngine;

public class TileSelector : MonoBehaviour, ISelectorEvents
{
    [SerializeField]
    private GameObject selectedTile;

    private readonly Selector<Tile> selector = new();

    public void SelectTile(Tile tile)
    {
        selector.Select(tile);
        selectedTile = selector.SelectedObject.TileTransform.gameObject;
    }

    public void Deselect()
    {
        selector.Deselect();
        selectedTile = null;
    }

    public Tile GetSelectedTile()
    {
        return selector.SelectedObject;
    }

    public void AddObserverToSelectedEvent(Action observer)
    {
        selector.Selected += observer;
    }

    public void AddObserverToDeselectedEvent(Action observer)
    {
        selector.Deselected += observer;
    }
}
