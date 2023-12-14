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

    override protected void Awake()
    {
        OptionSelected += tileSelector.SelectTile;

        options = map.GetTiles().Values.ToList();
        base.Awake();
        UpdateDropdown();
    }

    protected override void SetOptions()
    {
        throw new NotImplementedException();
    }

    protected override void UpdateDropdown()
    {
        foreach (var tile in map.GetTiles())
        {
            string optionText = tile.Value.Position.ToString();
            var option = new TMP_Dropdown.OptionData(optionText);
            dropdown.options.Add(option);
        }
    }
}
