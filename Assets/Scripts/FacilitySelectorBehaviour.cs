using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilitySelectorBehaviour: MonoBehaviour
{
    private readonly Selector<Facility> facilitySelector = new();

    public void SelectFacility(Facility facility)
    {
        facilitySelector.Select(facility);
    }

    public void Deselect()
    {
        facilitySelector.Deselect();
    }

    public Facility GetSelectedFacility()
    {
        return facilitySelector.SelectedObject;
    }

    public void AddObserverToSelectedEvent(Action observer)
    {
        facilitySelector.Selected += observer;
    }

    public void AddObserverToDeselectedEvent(Action observer)
    {
        facilitySelector.Deselected += observer;
    }
}
