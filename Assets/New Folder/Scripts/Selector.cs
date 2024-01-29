using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Selector<T>
{
    public T SelectedObject { get; private set; }
    public event Action Selected;
    public event Action Deselected;

    public void Select(T selected)
    {
        SelectedObject = selected;
        Selected?.Invoke();
    }

    public void Deselect()
    {
        SelectedObject = default;
        Deselected?.Invoke();
    }
}
