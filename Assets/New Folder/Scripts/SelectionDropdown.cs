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
    protected event Action Deselected;
    protected Dictionary<int, T> optionMenu = new();
    protected List<T> options = new();

    private const int noSelectionOption = 0;

    virtual protected void Awake()
    {
        AddOptionSelectedObservers();
        AddDeselectedObservers();
        dropdown.ClearOptions();
        SetOptions();
        InitialiseOptions();
        AddNoSelectionOption();
        AddDropdownOptions();
    }

    abstract protected void AddOptionSelectedObservers();

    abstract protected void AddDeselectedObservers();

    abstract protected void SetOptions();

    virtual protected void InitialiseOptions()
    {
        if (options.Count <= 0)
        {
            Debug.LogWarning("No options detected. Use set options.");
            return;
        }

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

    public void InvokeSelectionEvent()
    {
        if (dropdown.value == noSelectionOption)
        {
            Deselected?.Invoke();
        }
        else
        {
            T selectedOption = optionMenu[dropdown.value];
            OptionSelected?.Invoke(selectedOption);
        }
    }

    public void ResetSelectionToDefault()
    {
        dropdown.value = noSelectionOption;
        Deselected.Invoke();
    }

    public void ShowDropdown()
    {
        gameObject.SetActive(true);
    }

    public void HideDropdown()
    {
        ResetSelectionToDefault();
        gameObject.SetActive(false);
    }
}
