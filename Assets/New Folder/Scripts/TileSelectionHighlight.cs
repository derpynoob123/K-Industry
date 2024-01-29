using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelectionHighlight : MonoBehaviour
{
    [SerializeField]
    private TileSelector tileSelector;
    [SerializeField]
    private Transform selectedTileIcon;

    private void Awake()
    {
        tileSelector.AddObserverToSelectedEvent(HighlightSelectedTile);
        tileSelector.AddObserverToDeselectedEvent(RemoveHighlight);
    }

    public void HighlightSelectedTile()
    {
        selectedTileIcon.gameObject.SetActive(true);
        selectedTileIcon.position = tileSelector.GetSelectedTile().TileTransform.position;
    }

    public void RemoveHighlight()
    {
        selectedTileIcon.gameObject.SetActive(false);
    }
}
