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

    virtual protected void Awake()
    {
        dropdown.options.Clear();
    }
}
