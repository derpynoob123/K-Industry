using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class SelectionDropdown<T> : MonoBehaviour
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
        AddOptionSelectedObservers();
        dropdown.ClearOptions();
        SetOptions();
        InitialiseOptions();
        AddNoSelectionOption();
        AddDropdownOptions();
    }

    abstract protected void AddOptionSelectedObservers();

    abstract protected void SetOptions();

    virtual protected void InitialiseOptions()
    {
        for (int optionIndex = 0; optionIndex < options.Count; optionIndex++)
        {
            int optionValue = optionIndex + 1;
            optionMenu.Add(optionValue, options[optionIndex]);
        }
    }

    private void AddNoSelectionOption()
    {
        var option = new TMP_Dropdown.OptionData(noSelectionMessage);
        dropdown.options.Add(option);
    }

    abstract protected void AddDropdownOptions();

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
