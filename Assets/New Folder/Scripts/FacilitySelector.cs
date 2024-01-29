using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilitySelector: MonoBehaviour
{
    private readonly Selector<FacilityID> selector = new();

    public void SelectFacility(FacilityID facility)
    {
        selector.Select(facility);
    }

    public void Deselect()
    {
        selector.Deselect();
    }

    public FacilityID GetSelectedFacility()
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
