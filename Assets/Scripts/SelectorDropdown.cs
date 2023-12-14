using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class SelectorDropdown<T> : MonoBehaviour
{
    [SerializeField]
    protected TMP_Dropdown dropdown;
    [SerializeField]
    protected string noSelectionMessage;

    protected event Action<T> OptionSelected;
    protected Dictionary<int, T> optionMenu = new();

    private const int noSelectionOption = 0;

    protected void Awake()
    {
        dropdown.options.Clear();
    }

    protected void InitialiseOptions(T[] options)
    {
        var option = new TMP_Dropdown.OptionData(noSelectionMessage);
        dropdown.options.Add(option);
        for (int optionIndex = 0; optionIndex < options.Length; optionIndex++)
        {

        }
    }
}
