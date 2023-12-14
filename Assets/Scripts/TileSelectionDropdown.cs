using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TileSelectionDropdown : SelectionDropdown<Tile>
{
    [SerializeField]
    private MapBehaviour map;
    [SerializeField]
    private TileSelectorBehaviour tileSelector;

    override protected void Awake()
    {
        OptionSelected += tileSelector.SelectTile;
        base.Awake();
    }

    protected override void UpdateDropdown()
    {
        var option = new TMP_Dropdown.OptionData(noSelectionMessage);
        dropdown.options.Add(option);
        foreach (var tile in map.GetTiles())
        {
            string optionText = tile.Value.Position.ToString();
            option = new TMP_Dropdown.OptionData(optionText);
            dropdown.options.Add(option);
        }
    }
}
