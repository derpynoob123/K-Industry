using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VehicleSelector : MonoBehaviour
{
    private readonly Selector<VehicleController> selector = new();

    public void SelectVehicle(VehicleController vehicle)
    {
        selector.Select(vehicle);
    }

    public void Deselect()
    {
        selector.Deselect();
    }

    public VehicleController GetSelectedVehicle()
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
