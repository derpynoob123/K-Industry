using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class SelectorDropdown : MonoBehaviour
{
    [SerializeField]
    protected TMP_Dropdown dropdown;
    [SerializeField]
    protected string noSelectionMessage;
}
