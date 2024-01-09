using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TileSelectionDropdown : SelectionDropdown<Tile>
{
    [SerializeField]
    private MapBehaviour map;
    [SerializeField]
    private TileSelectorBehaviour tileSelector;

    protected override void AddOptionSelectedObservers()
    {
        OptionSelected += tileSelector.SelectTile;
    }

    protected override void SetOptions()
    {
        options = map.GetTiles().ToList();
        options = options.OrderBy(tile => tile.GridSpacePosition.x).ToList();
        options = options.OrderBy(tile => tile.GridSpacePosition.y).ToList();
    }

    protected override void AddDropdownOptions()
    {
        for (int optionIndex = 0; optionIndex < options.Count; optionIndex++)
        {
            string optionText = options[optionIndex].GridSpacePosition.ToString();
            var option = new TMP_Dropdown.OptionData(optionText);
            dropdown.options.Add(option);
        }
    }

    protected override void AddDeselectedObservers()
    {
        Deselected += tileSelector.Deselect;
    }
}
