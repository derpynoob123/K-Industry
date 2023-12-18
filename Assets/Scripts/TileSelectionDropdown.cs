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
        options = map.GetTiles().Values.ToList();
    }

    protected override void AddDropdownOptions()
    {
        foreach (var tile in map.GetTiles())
        {
            string optionText = tile.Value.GridSpacePosition.ToString();
            var option = new TMP_Dropdown.OptionData(optionText);
            dropdown.options.Add(option);
        }
    }
}
