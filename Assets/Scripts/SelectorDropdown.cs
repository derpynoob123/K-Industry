using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class SelectorDropdown<T> : MonoBehaviour
{
    [SerializeField]
    protected TMP_Dropdown dropdown;
    [SerializeField]
    protected string noSelectionMessage;

    protected event Action<T> OptionSelected;
    protected Dictionary<int, T> optionMenu = new();
    protected List<T> options;

    private const int noSelectionOption = 0;

    virtual protected void Awake()
    {
        dropdown.ClearOptions();
        InitialiseOptions();
    }

    virtual protected void InitialiseOptions()
    {
        var option = new TMP_Dropdown.OptionData(noSelectionMessage);
        dropdown.options.Add(option);
        for (int optionIndex = 0; optionIndex < options.Count; optionIndex++)
        {
            string optionText = $"Option {optionIndex + 1}";
            option = new TMP_Dropdown.OptionData(optionText);
            dropdown.options.Add(option);
            optionMenu.Add(optionIndex, options[optionIndex]);
        }
    }
    public void SelectOption()
    {
        if (dropdown.value == noSelectionOption)
        {
            return;
        }
        T selectedOption = optionMenu[dropdown.value];
        OptionSelected.Invoke(selectedOption);
    }
}
