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

    private void Awake()
    {
        dropdown.options.Clear();
        InitialiseOptions();
    }

    private void InitialiseOptions()
    {
        foreach (var tile in map.GetTiles())
        {;
            string optionText = tile.Value.Position.ToString();
            var option = new TMP_Dropdown.OptionData(optionText);
            dropdown.options.Add(option);
        }
    }
}
