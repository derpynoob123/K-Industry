using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WindowSelector : MonoBehaviour, ISelectorEvents
{
    private readonly Selector<GameObject> selector = new();

    public void SelectWindow(GameObject window)
    {
        selector.Select(window);
    }

    public void Deselect()
    {
        selector.Deselect();
    }

    public GameObject GetWindow()
    {
        return selector.SelectedObject;
    }

    public void AddObserverToSelectedEvent(Action observer)
    {
        selector.Selected += observer;
    }

    public void AddObserverToDeselectedEvent(Action observer)
    {
        selector.Deselected += observer;
    }
}
