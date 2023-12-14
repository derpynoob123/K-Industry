using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TileSelectionDropdown : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown dropdown;
    [SerializeField]
    private MapBehaviour map;
    [SerializeField]
    private TileSelectorBehaviour tileSelector;
    [SerializeField]
    private string noSelectionMessage;

    private event Action<Tile> TileSelected;
    private Dictionary<int, Tile> tileMenu = new();

    private const int noSelectionOption = 0;

    private void Awake()
    {
        TileSelected += tileSelector.SelectTile;
        dropdown.options.Clear();
        InitialiseOptions();
    }

    private void InitialiseOptions()
    {
        var option = new TMP_Dropdown.OptionData(noSelectionMessage);
        dropdown.options.Add(option);
        int menuIndex = 0;
        foreach (var tile in map.GetTiles())
        {
            string optionText = tile.Value.Position.ToString();
            option = new TMP_Dropdown.OptionData(optionText);
            dropdown.options.Add(option);
            tileMenu.Add(menuIndex, tile.Value);
            menuIndex++;
        }
    }

    public void SelectOption()
    {
        if (dropdown.value == noSelectionOption)
        {
            return;
        }
        SelectTile();
    }

    private void SelectTile()
    {
        Tile selectedTile = tileMenu[dropdown.value];
        TileSelected.Invoke(selectedTile);
    }
}
